using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionNode : MonoBehaviour
{
    public float radius = 1f;



    public bool CollidesWith(CollisionNode other)
    {
        return Universe.instance.Distance(position, other.position) < radius + other.radius;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }



    private Color gizmoColor
    {
        get
        {
            if (manager == null) return Color.red;
            switch (manager.group)
            {
                case CollisionManager.Group.Asteroid:
                    return Color.yellow;
                case CollisionManager.Group.Missile:
                    return Color.white;
                case CollisionManager.Group.Player:
                    return Color.green;
            }
            return Color.red;
        }
    }



    private CollisionManager manager => GetComponentInParent<CollisionManager>();



    public Vector2 position => transform.position;
}
