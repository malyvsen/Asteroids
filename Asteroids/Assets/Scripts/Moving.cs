using System.Collections;
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
    }



    protected void LocalSpawn(GameObject prototype)
    {
        var spawned = Instantiate(prototype);
        var moving = spawned.GetComponent<Moving>();
        moving.position = position;
        moving.velocity = velocity;
        moving.forward = forward;
    }



    public List<Moving> collidesWith
    {
        get
        {
            var result = new List<Moving>();
            foreach (var collisionNode in GetComponentsInChildren<CollisionNode>())
            {
                foreach (var collidedNode in collisionNode.collidesWith)
                {
                    var toAdd = collidedNode.GetComponentInParent<Moving>();
                    if (toAdd == this) continue;
                    if (result.Contains(toAdd)) continue;
                    result.Add(toAdd);
                }
            }
            return result;
        }
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
