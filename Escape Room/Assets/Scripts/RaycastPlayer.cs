using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastPlayer : MonoBehaviour
{
    RaycastHit hit;
    Ray raycast;
    public Text towersInteract;
    public int raycastLength;

    void Start()
    {
        towersInteract.enabled = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, forward, out hit, raycastLength)) 
        {
            if (hit.collider.gameObject.name == "puzzle1_trigger")
            {
                if (towersInteract.enabled == false)
                {
                    towersInteract.enabled = true; //Set interact text to visible
                }
                
                if (Input.GetKey(KeyCode.E))
                {
                    //Transfer player to the towers of hanoi puzzle scene - don't forget to pass puzzle variables if not done already!
                    //To do: Save current location of player to this, call back when the player leaves the puzzle
                    Debug.Log("E pressed!");
                    PlayerPrefs.SetFloat("playerXCoord", transform.position.x);
                    PlayerPrefs.SetFloat("playerYCoord", transform.position.y);
                    PlayerPrefs.SetFloat("playerZCoord", transform.position.z);
                    //SceneManager.SetActiveScene
                }
            }
        }
        else
        {
            if (towersInteract.enabled == true) //Set interact text to invisible if it is visible (triggered when looking away)
            {
                towersInteract.enabled = false; 
            }
        }
    }
}
