using System.Linq;
using UnityEngine;



public class Player : Moving
{
    public static Player instance;

    public float acceleration = 2f;
    public float maxSpeed = 16f;
    public float turnSpeed = 360f;

    public GameObject missile = null;



    private void OnEnable()
    {
        if (instance != null) throw new System.NotSupportedException("Cannot have multiple players enabled at the same time");
        instance = this;
    }



    private void OnDisable()
    {
        instance = null;
    }



    private void Update()
    {
        ControlMovement();
        ApplyPhysics();
        ControlShooting();
        if (collisions.Any())
        {
            Explode();
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



    private void ControlShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }



    private void Shoot()
    {
        LocalSpawn(missile);
    }



    private void Explode()
    {
        Game.instance.EndRound();
        Destroy(gameObject);
    }
}
