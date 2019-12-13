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
        //Rotate using arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3((-1 * Input.GetAxis("Vertical") * rotationSpeed * Time.fixedDeltaTime), 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3((-1 * Input.GetAxis("Vertical") * rotationSpeed * Time.fixedDeltaTime), 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, (Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime), 0.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, (Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime), 0.0f));
        }

        //Movement using WASD
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, movementSpeed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, movementSpeed * -1)); //multiplied by -1 to go opposite direction
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(new Vector3(movementSpeed * -1 , 0.0f, 0.0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(new Vector3(movementSpeed, 0.0f, 0.0f));
        }
    }
}

