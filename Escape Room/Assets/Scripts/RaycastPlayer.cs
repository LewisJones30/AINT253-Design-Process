using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastPlayer : MonoBehaviour
{
    RaycastHit hit;
    Ray raycast;
    public Text towersInteract;

    void Start()
    {
        towersInteract.enabled = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 2.5f;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            if (hit.collider.gameObject.name == "puzzle1_trigger")
            {
                if (towersInteract.enabled == false)
                {
                    towersInteract.enabled = true;
                }
                //Transfer player to the towers of hanoi puzzle scene - don't forget to pass puzzle variables if not done already!
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("E pressed!");
                }
            }
        }
        else
        {
            if (towersInteract.enabled == true)
            {
                towersInteract.enabled = false;
            }
        }
    }
}
