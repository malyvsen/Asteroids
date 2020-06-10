using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Missile : AsteroidsObject
{
    public float speed = 32f;



    private void Start()
    {
        velocity = forward * speed;
    }



    private void Update()
    {
        ApplyPhysics();
    }
}
