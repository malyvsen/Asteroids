using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionNode : MonoBehaviour
{
    public float radius = 1f;
    public Group group = Group.Unknown;



    private void OnEnable()
    {
        if (nodesByGroup == null) nodesByGroup = new Dictionary<Group, List<CollisionNode>>();
        if (!nodesByGroup.ContainsKey(group)) nodesByGroup[group] = new List<CollisionNode>();
        nodesByGroup[group].Add(this);
    }



    private void OnDisable()
    {
        nodesByGroup[group].Remove(this);
    }



    [HideInInspector]
    public List<CollisionNode> collidesWith = new List<CollisionNode>();

    private void LateUpdate()
    {
        collidesWith = new List<CollisionNode>();
        var checkCollisions = new List<CollisionNode>();
        foreach (Group otherGroup in System.Enum.GetValues(typeof(Group)))
        {
            if (!GroupsCollide(group, otherGroup)) continue;
            foreach (var otherNode in NodesByGroup(otherGroup))
            {
                if (Vector2.Distance(position, otherNode.position) < radius + otherNode.radius)
                {
                    collidesWith.Add(otherNode);
                }
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }



    public enum Group
    {
        Unknown = -1,
        Asteroid,
        Missile,
        Player
    }



    // Player & Missile only collide with Asteroid,
    // Asteroid collides with everything
    public static bool GroupsCollide(Group a, Group b)
    {
        if (a == Group.Unknown || b == Group.Unknown) return false;
        if (a == Group.Asteroid || b == Group.Asteroid) return true;
        return false;
    }



    private static Dictionary<Group, List<CollisionNode>> nodesByGroup = null;

    private static List<CollisionNode> NodesByGroup(Group group)
    {
        if (nodesByGroup == null) return new List<CollisionNode>();
        if (!nodesByGroup.ContainsKey(group)) return new List<CollisionNode>();
        return nodesByGroup[group];
    }



    public Vector2 position => transform.position;
}
