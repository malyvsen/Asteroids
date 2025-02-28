﻿using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;



public abstract class Moving : MonoBehaviour
{
    public float drag = 4f;



    protected void ApplyPhysics()
    {
        position += velocity * Time.deltaTime;
        position = Universe.instance.Wrap(position);
        velocity *= Mathf.Exp(-drag * Time.deltaTime);
        transform.Rotate(0f, 0f, angularVelocity * Time.deltaTime);
    }



    protected Moving LocalSpawn(GameObject prototype)
    {
        var spawned = Instantiate(prototype);
        spawned.transform.parent = transform.parent;
        var moving = spawned.GetComponent<Moving>();
        moving.position = position;
        moving.velocity = velocity;
        moving.forward = forward;
        moving.angularVelocity = angularVelocity;
        return moving;
    }



    public Vector2 position
    {
        get => transform.position;
        set => transform.position = value;
    }

    [HideInInspector]
    public Vector2 velocity = Vector2.zero;

    public Vector2 forward
    {
        get => transform.up;
        set => transform.up = value;
    }

    [HideInInspector]
    public float angularVelocity = 0f;



    public IEnumerable<Moving> collisions => GetComponentInChildren<CollisionManager>().collisions.Select(manager => manager.GetComponentInParent<Moving>());
}
