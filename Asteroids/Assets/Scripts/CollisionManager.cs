using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionManager : MonoBehaviour
{
    public Group group = Group.Unknown;



    private void OnEnable()
    {
        if (enabledManagers == null) enabledManagers = new Dictionary<Group, List<CollisionManager>>();
        if (!enabledManagers.ContainsKey(group)) enabledManagers[group] = new List<CollisionManager>();
        enabledManagers[group].Add(this);
    }



    private void OnDisable()
    {
        enabledManagers[group].Remove(this);
    }



    [HideInInspector]
    public List<CollisionManager> collisions = new List<CollisionManager>();

    private void LateUpdate()
    {
        collisions = new List<CollisionManager>();
        var checkCollisions = new List<CollisionNode>();
        foreach (Group otherGroup in System.Enum.GetValues(typeof(Group)))
        {
            if (!GroupsCollide(group, otherGroup)) continue;
            foreach (var otherManager in EnabledManagers(otherGroup))
            {
                if (otherManager == this) continue;
                bool collision = false;
                foreach (var node in nodes)
                {
                    foreach (var otherNode in otherManager.nodes)
                    {
                        if (Vector2.Distance(node.position, otherNode.position) < node.radius + otherNode.radius)
                        {
                            collision = true;
                        }
                        if (collision) break;
                    }
                    if (collision) break;
                }
                if (collision) collisions.Add(otherManager);
            }
        }
    }



    public IEnumerable<CollisionNode> nodes => GetComponentsInChildren<CollisionNode>();



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



    private static Dictionary<Group, List<CollisionManager>> enabledManagers = null;

    private static List<CollisionManager> EnabledManagers(Group group)
    {
        if (enabledManagers == null) return new List<CollisionManager>();
        if (!enabledManagers.ContainsKey(group)) return new List<CollisionManager>();
        return enabledManagers[group];
    }
}
