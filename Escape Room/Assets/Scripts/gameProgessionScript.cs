using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameProgessionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hanoiLight;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Debug.Log("Reset progress.");
            //Reset ALL player preferences here!
            PlayerPrefs.SetInt("puzzle1Complete", 0); //Reset towers of hanoi puzzle
        }

        
        //Testing
        
        /*
         * This script is designed for the flow of progression to occur between scenes where required. This script is to be applied to the main camera script.
         * PlayerPrefs guide:
         * puzzle1Complete - Towers of Hanoi completion. 0 = not complete, 1 = complete, 2 = pressed back button
         * 
         */
        if (PlayerPrefs.GetInt("puzzle1Complete") == 1) //If the towers of hanoi puzzle has been completed
        {
            Animator anim = hanoiLight.GetComponent<Animator>();
            anim.SetTrigger("completedPuzzle"); //Trigger the light above the puzzle to be completed
            //Next stage in progression.
        }
        else if (PlayerPrefs.GetInt("puzzle1Complete") == 2)
        {
            GameObject camera = GameObject.Find("Main Camera");
            Vector3 playerLocation = new Vector3(PlayerPrefs.GetFloat("playerXCoord"), PlayerPrefs.GetFloat("playerYCoord"), PlayerPrefs.GetFloat("playerZCoord"));
            Debug.Log(playerLocation);
            camera.transform.position = playerLocation;
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
}
