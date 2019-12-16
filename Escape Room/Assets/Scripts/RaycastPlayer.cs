using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastPlayer : MonoBehaviour
{
    RaycastHit hit;
    Ray raycast;
    public Text towersInteract, incorrectmessage, bookTextDisplay, closeText;
    public int raycastLength;
    public Timer timeRemainingScript;
    private LightPuzzle lightpuzzleScript;
    float raycastLimiter = 0.0f;
    public Button close;
    public Image terminalBackground;
    public Text terminalText;
    void Start()
    {
        towersInteract.enabled = false;
        lightpuzzleScript = this.GetComponentInParent<LightPuzzle>();
        incorrectmessage.enabled = false;
        bookTextDisplay.enabled = false;
        close.enabled = false;
        closeText.enabled = false;
        terminalBackground.enabled = false;
        terminalText.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        raycastLimiter += Time.deltaTime;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.red);
        if (raycastLimiter >= 0.15f)
        {
            raycastLimiter = 0f;
            if (Physics.Raycast(transform.position, forward, out hit, raycastLength))
            {
                if (hit.collider.gameObject.name == "puzzle1_trigger")
                {
                    if (PlayerPrefs.GetInt("puzzle1Complete") == 1)
                    {
                        return;
                    }
                    if (towersInteract.enabled == false)
                    {
                        towersInteract.enabled = true; //Set interact text to visible
                    }

                    if (Input.GetKey(KeyCode.E))
                    {
                        if (PlayerPrefs.GetInt("puzzle1Complete") == 3)
                        {
                            StartCoroutine("interactTowersEarly");
                            Debug.Log("Message");
                            return;
                        }
                        else
                        {
                            //Transfer player to the towers of hanoi puzzle scene - don't forget to pass puzzle variables if not done already!
                            //To do: Save current location of player to this, call back when the player leaves the puzzle
                            PlayerPrefs.SetFloat("playerXCoord", transform.position.x); //Currently unused
                            Debug.Log(transform.position.x);
                            PlayerPrefs.SetFloat("playerYCoord", transform.position.y); //Currently unused
                            Debug.Log(transform.position.y);
                            PlayerPrefs.SetFloat("playerZCoord", transform.position.z); //Currently unused
                            Debug.Log(transform.position.z);
                            PlayerPrefs.SetFloat("timeRemaining", timeRemainingScript.getTimeRemaining()); //Set time remaining
                            timeRemainingScript.freezeTime();
                            Debug.Log(timeRemainingScript.getTimeRemaining());
                            SceneManager.LoadScene("towersOfHanoiPuzScene");
                            Debug.Log("E pressed!");
                        }
                    }
                }
                /*
                 * Light puzzle interaction code starts here...
                 */
                else if (hit.collider.gameObject.name == "Button1") //Light puzzle button 1
                {
                    if (towersInteract.enabled == false)
                    {
                        towersInteract.enabled = true; //Set interact text to visible

                    }
                    towersInteract.text = "Press E to push button 1.";
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (PlayerPrefs.GetInt("lightPuzzleStatus") == 0)
                        {
                            Debug.Log("Status = 0");
                            StartCoroutine("incorrectButtonPress");

                        }
                        else if (PlayerPrefs.GetInt("lightPuzzleStatus") == 1)
                        {
                            lightpuzzleScript.UnlockedButtonPress("Button1");
                        }
                    }

                }
                else if (hit.collider.gameObject.name == "Button2") //Light puzzle button 2
                {
                    if (towersInteract.enabled == false)
                    {
                        towersInteract.enabled = true; //Set interact text to visible

                    }
                    towersInteract.text = "Press E to push button 2.";
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (PlayerPrefs.GetInt("lightPuzzleStatus") == 0)
                        {
                            StartCoroutine("incorrectButtonPress");
                        }
                        else if (PlayerPrefs.GetInt("lightPuzzleStatus") == 1)
                        {
                            lightpuzzleScript.UnlockedButtonPress("Button2");
                        }
                    }
                }
                else if (hit.collider.gameObject.name == "Button3")
                {
                    if (towersInteract.enabled == false)
                    {
                        towersInteract.enabled = true; //Set interact text to visible

                    }
                    towersInteract.text = "Press E to push button 3.";
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (PlayerPrefs.GetInt("lightPuzzleStatus") == 0)
                        {
                            StartCoroutine("incorrectButtonPress");

                        }
                        else if (PlayerPrefs.GetInt("lightPuzzleStatus") == 1)
                        {
                            lightpuzzleScript.UnlockedButtonPress("Button3");
                        }
                    }
                }

                else if (hit.collider.gameObject.name == "Button4")
                {
                    if (towersInteract.enabled == false)
                    {
                        towersInteract.enabled = true; //Set interact text to visible

                    }
                    towersInteract.text = "Press E to push button 4.";
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (PlayerPrefs.GetInt("lightPuzzleStatus") == 0)
                        {
                            StartCoroutine("incorrectButtonPress");
                        }
                        else if (PlayerPrefs.GetInt("lightPuzzleStatus") == 1)
                        {
                            lightpuzzleScript.UnlockedButtonPress("Button4");
                        }

                    }
                }
                /*
                 * General interaction goes here
                 */
                else if (hit.collider.gameObject.name == "Computer Terminal V1 - Off")
                {
                    StartCoroutine("earlyComputer");
                    return;
                }
                else if (hit.collider.gameObject.name == "Computer Terminal V1 - On")
                {
                    //Display text here
                    PlayerPrefs.SetInt("lightPuzzleStatus", 1); //Enables the light puzzle to be interacted with.
                }
                else if (hit.collider.gameObject.name == "Old book V1")
                {
                    if (towersInteract.enabled == false)
                    {
                        towersInteract.enabled = true;
                    }
                    if (Input.GetKey(KeyCode.E))
                    {
                        bookTextDisplay.enabled = true;
                        close.enabled = true;
                        closeText.enabled = true;
                    }
                }
                /*
                 * Terminal interaction
                 */
                else if (hit.collider.gameObject.name == "Computer Terminal V1 - On (Clone)")
                {
                    if (towersInteract.enabled == false)
                    {
                        towersInteract.enabled = true;
                    }
                    if (Input.GetKey(KeyCode.E))
                    {
                        PlayerPrefs.SetInt("lightPuzzleStatus", 1); //Enables the light puzzle to be interacted with.
                        terminalBackground.enabled = true;
                        terminalText.enabled = true;
                    }
                    
                }
            }


            else
            {
                if (towersInteract.enabled) //Set interact text to invisible if it is visible (triggered when looking away)
                {
                    towersInteract.enabled = false;
                }
            }
        }

    }
    IEnumerator incorrectButtonPress()
    {
        lightpuzzleScript.notUnlockedButtonPress();
        incorrectmessage.enabled = true;
        yield return new WaitForSeconds(2.5f);
        incorrectmessage.text = "Maybe I need to look elsewhere...";
        yield return new WaitForSeconds(5);
        incorrectmessage.enabled = false;
    }
    IEnumerator ButtonPress()
    {

        incorrectmessage.enabled = true;
        incorrectmessage.text = "I hear a click nearby.. Am I free?";
        yield return new WaitForSeconds(5);
        incorrectmessage.enabled = false;
    }
    IEnumerator interactTowersEarly()
    {
        incorrectmessage.enabled = true;
        incorrectmessage.text = "I don't know what to do here yet...";
        yield return new WaitForSeconds(5);
        incorrectmessage.text = "Maybe I should look around for some instructions.";
        yield return new WaitForSeconds(3);
        incorrectmessage.enabled = false;
    }
    IEnumerator earlyComputer()
    {
        incorrectmessage.enabled = true;
        incorrectmessage.text = "The computer terminal is off. I have no use for this.";
        yield return new WaitForSeconds(5);
        incorrectmessage.enabled = false;
    }
    public void closeBookText()
    {
        if (bookTextDisplay.enabled == true)
        {
            bookTextDisplay.enabled = false;
            close.enabled = false;
            closeText.enabled = false;
            if (PlayerPrefs.GetInt("puzzle1Complete") == 3)
            {
                PlayerPrefs.SetInt("puzzle1Complete", 0); //Set towers puzzle as openable
            }

        }
    }
    public void closeTerminalText()
    {
        if (terminalText.enabled == true)
        {
            terminalText.enabled = false;
            terminalBackground.enabled = false;
            if (PlayerPrefs.GetInt("lightPuzzleStatus") == 0)
            {
                PlayerPrefs.SetInt("lightPuzzleStatus", 1);
            }
        }
    }
}


