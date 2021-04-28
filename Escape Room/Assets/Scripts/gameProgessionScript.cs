using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameProgessionScript : MonoBehaviour
{
    //Public Variables

    //SerializeField variables
    [SerializeField]
    GameObject hanoiLight;
    [SerializeField]
    GameObject terminalOn;
    [SerializeField]
    GameObject terminal;
    [SerializeField]
    AudioSource bootSound;
    [SerializeField]
    Light light;
    [SerializeField]
    Text topText;
    [SerializeField]
    Timer timer;
    //Private variables

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Debug.Log("Reset progress.");
            //Reset ALL player preferences here!
            PlayerPrefs.SetInt("puzzle1Complete", 3); //Reset towers of hanoi puzzle to state 3 - button push required.
            PlayerPrefs.SetInt("lightPuzzleStatus", 0);
        }
        Debug.Log(PlayerPrefs.GetInt("puzzle1Complete"));
        Debug.Log(PlayerPrefs.GetInt("lightPuzzleStatus"));
        /*
         * This script is designed for the flow of progression to occur between scenes where required. This script is to be applied to the main camera script.
         * PlayerPrefs guide:
         * puzzle1Complete - Towers of Hanoi completion. 0 = not complete, 1 = complete, 2 = pressed back button, 3 = Not read book
         * lightPuzzleStatus - Light puzzle status. 0 = Not unlocked, 1 = Unlocked, 2 = Complete (When it equals 2 the game is completed)
         * 
         * 
         */
        if (PlayerPrefs.GetInt("puzzle1Complete") == 1) //If the towers of hanoi puzzle has been completed
        {
            GameObject camera = GameObject.FindWithTag("MainCamera");
            light.color = Color.green;
            light.intensity = 0.25f;
            Animator anim = hanoiLight.GetComponent<Animator>();
            anim.SetTrigger("completedPuzzle"); //Trigger the light above the puzzle to be completed
            Vector3 playerLocation = new Vector3(PlayerPrefs.GetFloat("playerXCoord"), PlayerPrefs.GetFloat("playerYCoord"), PlayerPrefs.GetFloat("playerZCoord"));
            camera.transform.position = playerLocation;
            bootSound.Play();
            TerminalUpdate();
            timer.SetTimeRemaining(PlayerPrefs.GetFloat("timeRemaining"));
            StartCoroutine("TerminalMessage");

        }
        else if (PlayerPrefs.GetInt("puzzle1Complete") == 2) //If the player has "quit" the puzzle. 
        {
            GameObject camera = GameObject.FindWithTag("MainCamera");
            Vector3 playerLocation = new Vector3(PlayerPrefs.GetFloat("playerXCoord"), PlayerPrefs.GetFloat("playerYCoord"), PlayerPrefs.GetFloat("playerZCoord"));
            Debug.Log(playerLocation);
            camera.transform.position = playerLocation;
        }
        else if (PlayerPrefs.GetInt("lightPuzzleStatus") == 1)
        {
            TerminalUpdate();
            Debug.Log("Terminal change executed.");

        } 

    }   
    void TerminalUpdate()
    {
        Vector3 firstObjectPos = new Vector3(terminal.transform.position.x, terminal.transform.position.y, terminal.transform.position.z);
        Debug.Log(firstObjectPos);
        Destroy(terminal);
        Quaternion rotation;
        rotation = Quaternion.Euler(0, 180, 0);
        Instantiate(terminalOn, firstObjectPos, rotation);


    }
    IEnumerator TerminalMessage()
    {
        topText.enabled = true;
        topText.text = "I hear a noise...";
        yield return new WaitForSeconds(5);
        topText.enabled = false;

    }
}
