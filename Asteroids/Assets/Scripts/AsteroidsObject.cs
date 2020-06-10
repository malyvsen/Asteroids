using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class AsteroidsObject : MonoBehaviour
{
    public float drag = 4f;



    protected void ApplyPhysics()
    {
        position += velocity * Time.deltaTime;
        velocity *= Mathf.Exp(-drag * Time.deltaTime);
    }



    protected void LocalSpawn(GameObject prototype)
    {
        var spawned = Instantiate(prototype);
        var asteroidsObject = spawned.GetComponent<AsteroidsObject>();
        asteroidsObject.position = position;
        asteroidsObject.velocity = velocity;
        asteroidsObject.forward = forward;
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
}
