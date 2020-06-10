using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public float acceleration = 1f;
    public float maxSpeed = 1f;
    public float drag = 4f;
    public float controlRadius = 0.1f;



    private void Update()
    {
        ControlMovement();
        ApplyPhysics();
    }



    private void ControlMovement()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var toMouse = mousePos - position;
            if (toMouse.magnitude > controlRadius)
            {
                var velocityChange = toMouse.normalized * acceleration * Time.deltaTime;
                var newVelocity = velocity + velocityChange;
                if (newVelocity.magnitude < maxSpeed || newVelocity.magnitude < velocity.magnitude)
                {
                    velocity = newVelocity;
                }
            }
        }
    }



    private void ApplyPhysics()
    {
        position += velocity;
        velocity *= Mathf.Exp(-drag * Time.deltaTime);
    }



    public Vector2 position
    {
        get => transform.position;
        set => transform.position = value;
    }

    private Vector2 velocity = Vector2.zero;
}
