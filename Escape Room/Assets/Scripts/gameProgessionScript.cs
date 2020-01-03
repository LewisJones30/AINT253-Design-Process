using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameProgessionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hanoiLight;
    public GameObject terminalOn;
    public GameObject terminal;
    public AudioSource bootSound;
    public Light light;
    public Text topText;
    public Timer timer;
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
        //testing
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
            GameObject camera = GameObject.Find("Main Camera");
            light.color = Color.green;
            light.intensity = 0.25f;
            Animator anim = hanoiLight.GetComponent<Animator>();
            anim.SetTrigger("completedPuzzle"); //Trigger the light above the puzzle to be completed
            Vector3 playerLocation = new Vector3(PlayerPrefs.GetFloat("playerXCoord"), PlayerPrefs.GetFloat("playerYCoord"), PlayerPrefs.GetFloat("playerZCoord"));
            camera.transform.position = playerLocation;
            bootSound.Play();
            terminalUpdate();
            timer.setTimeRemaining(PlayerPrefs.GetFloat("timeRemaining"));
            StartCoroutine("terminalMessage");

        }
        else if (PlayerPrefs.GetInt("puzzle1Complete") == 2) //If the player has "quit" the puzzle. 
        {
            GameObject camera = GameObject.Find("Main Camera");
            Vector3 playerLocation = new Vector3(PlayerPrefs.GetFloat("playerXCoord"), PlayerPrefs.GetFloat("playerYCoord"), PlayerPrefs.GetFloat("playerZCoord"));
            Debug.Log(playerLocation);
            camera.transform.position = playerLocation;
        }
        else if (PlayerPrefs.GetInt("lightPuzzleStatus") == 1)
        {
            terminalUpdate();
            Debug.Log("Terminal change executed.");

        } 

    }   

    // Update is called once per frame
    void Update()
    {

    }

    void newGameCode() //This can be called at the start of each game to reset the entire escape room. All of the player prefs will be entirely reset here.
    {
        PlayerPrefs.SetInt("puzzle1Complete", 0); 

    }
    void terminalUpdate()
    {
        Vector3 firstObjectPos = new Vector3(terminal.transform.position.x, terminal.transform.position.y, terminal.transform.position.z);
        Debug.Log(firstObjectPos);
        Destroy(terminal);
        Quaternion rotation;
        rotation = Quaternion.Euler(0, 180, 0);
        Instantiate(terminalOn, firstObjectPos, rotation);


    }
    IEnumerator terminalMessage()
    {
        topText.enabled = true;
        topText.text = "I hear something in the background as the puzzle completes...";
        yield return new WaitForSeconds(5);
        topText.enabled = false;

    }
    void gameCompletion()
    {
        if (PlayerPrefs.GetInt("lightPuzzleStatus") == 2) //Puzzle completed, player has completed the puzzle.
        {
            
        }
    }
}
