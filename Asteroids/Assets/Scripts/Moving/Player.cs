using System.Linq;
using UnityEngine;



public class Player : Moving
{
    public float acceleration = 2f;
    public float maxSpeed = 16f;
    public float turnSpeed = 360f;

    public GameObject missile = null;
    public float shotsPerSecond = 2f;

    public GameObject explodeEffect = null;



    private void Update()
    {
        ControlMovement();
        ApplyPhysics();
        ControlShooting();
        if (collisions.Any())
        {
            Instantiate(explodeEffect);
            Game.instance.EndRound();
        }
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



    private float lastShotTime = float.NegativeInfinity;

    private void ControlShooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time > lastShotTime + 1f / shotsPerSecond)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }



    private void Shoot()
    {
        LocalSpawn(missile);
    }
}
