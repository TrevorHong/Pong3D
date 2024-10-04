using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 3f;
    private InputActions inputActions;
    private InputAction movement;

     private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        inputActions = new InputActions();
        movement = inputActions.Player.Movement;
    }
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>();

        Vector3 v3 = new Vector3(v2.x, 0, v2.y);

        rb.velocity = v3 * speed;
    }
}
