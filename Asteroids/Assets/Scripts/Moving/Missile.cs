using System.Linq;
using UnityEngine;



public class Missile : Moving
{
    public float speed = 32f;
    public float lifetime = 0.5f;



    private void Start()
    {
        lifeStart = Time.time;
        velocity = forward * speed;
    }



    private void Update()
    {
        ApplyPhysics();
        if (collisions.Any() || Time.time > lifeStart + lifetime)
        {
            Explode();
        }
    }



    private void Explode()
    {
        Destroy(gameObject);
    }



    private float lifeStart = 0f;
}
