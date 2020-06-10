using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : AsteroidsObject
{
    public float acceleration = 2f;
    public float maxSpeed = 16f;
    public float turnSpeed = 360f;

    public GameObject missile = null;



    private void Update()
    {
        ControlMovement();
        ApplyPhysics();
        ControlShooting();
    }



    private void ControlMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) Turn(false);
        if (Input.GetKey(KeyCode.RightArrow)) Turn(true);
        if (Input.GetKey(KeyCode.UpArrow)) Accelerate();
    }



    private void Turn(bool right)
    {
        var angularSpeed = right ? -turnSpeed : turnSpeed;
        var angleChange = angularSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, angleChange);
    }



    private void Accelerate()
    {
        var velocityChange = forward * acceleration * Time.deltaTime;
        var newVelocity = velocity + velocityChange;
        if (newVelocity.magnitude < maxSpeed || newVelocity.magnitude < velocity.magnitude)
        {
            velocity = newVelocity;
        }
    }



    private void ControlShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }



    private void Shoot()
    {
        LocalSpawn(missile);
    }
}
