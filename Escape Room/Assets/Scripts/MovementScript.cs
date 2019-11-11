using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    Rigidbody player;
    public float movementSpeed = 15; //Multiplier for movement speed
    public float rotationSpeed = 10; //Multiplier for rotation speed
    public Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, movementSpeed * - 1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0.0f, (Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime), 0.0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, movementSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0.0f, (Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime), 0.0f));
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3((Input.GetAxis("Vertical")* rotationSpeed * Time.fixedDeltaTime), 0.0f, 0.0f));
        }
    }
}

