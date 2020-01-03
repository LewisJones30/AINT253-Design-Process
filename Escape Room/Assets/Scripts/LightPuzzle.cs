using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lights = new GameObject[24];
    public Material onMaterial;
    public Material offMaterial;
    public Text incorrectbuttonPush;
    public GameObject button1, button2, button3, button4;
    private int currentInputStatus = 0;
    RaycastPlayer textScript;
    new AudioSource audio;
    //public Animation btnpush, btnpush2, btnpush3, btnpush4;

    public AudioClip buttonPress, successfulPress;
    void Start()
    {
        textScript = GetComponentInChildren<RaycastPlayer>();
        audio = GameObject.Find("Buttons for Light Puzzle").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void notUnlockedButtonPress() //This is launched when the player has not unlocked the puzzle yet to prevent interaction.

    {
        randomLightsMovement(true);
        button1.GetComponent<BoxCollider>().enabled = false;
        button2.GetComponent<BoxCollider>().enabled = false;
        button3.GetComponent<BoxCollider>().enabled = false;
        button4.GetComponent<BoxCollider>().enabled = false;
        audio.clip = successfulPress;
        audio.Play();
    }
    public void UnlockedButtonPress(string buttonPushed) //This is executed when the player has unlocked the puzzle. Once they input the correct code, the door will open and the player is able to escape the room.
    {
        //Button solution is... 4, 2, 3, 1, 4
        //Random light switching but record the order they pressed it in
        //Five lights on the top will indicate if it has been completed in the right order.
        //Check status of the five lights on top.
        if (currentInputStatus == 0)
        {
            if (buttonPushed == "Button4")
            {
                currentInputStatus = 1;
                Debug.Log("Correct, 1/5");
                randomLightsMovement(false);
                // btnpush4.wrapMode = WrapMode.Once;
                button4.GetComponent<Animator>().Play("btnPush4", -1, 0f);
                //btnpush4.Play();


                audio.clip = successfulPress;
                audio.Play();
            }
            else
            {
                currentInputStatus = 0;
                randomLightsMovement(false);
                //btnpush4.wrapMode = WrapMode.Once;
                //btnpush4.Play();
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);
                audio.clip = buttonPress;
                audio.Play();
            }

        }
        else if (currentInputStatus == 1)
        {
            if (buttonPushed == "Button2")
            {
                currentInputStatus = 2;
                Debug.Log("Correct, 1/5");
                randomLightsMovement(false);
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);

                audio.clip = successfulPress;
                audio.Play();
            }
            else 
            {
                currentInputStatus = 0;
                //Incorrect sound
                randomLightsMovement(false);
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);
                audio.clip = buttonPress;
                audio.Play();
            }
        }
        else if (currentInputStatus == 2)
        {
            if (buttonPushed == "Button3")
            {
                currentInputStatus = 3;
                Debug.Log("Correct, 1/5");
                randomLightsMovement(false);
                audio.clip = successfulPress;
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);
                audio.Play();
            }
            else
            {
                currentInputStatus = 0;
                //Incorrect sound
                randomLightsMovement(false);
                audio.clip = buttonPress;
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);
                audio.Play();
            }
        }
        else if (currentInputStatus == 3)
        {
            if (buttonPushed == "Button1")
            {
                currentInputStatus = 4;
                Debug.Log("Correct, 1/5");
                randomLightsMovement(false);
                audio.clip = successfulPress;
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);
                audio.Play();
            }
            else
            {
                currentInputStatus = 0;
                randomLightsMovement(false);
                audio.clip = buttonPress;
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);
                audio.Play();
            }
        }
        else if (currentInputStatus == 4)
        {
            if (buttonPushed == "Button4")
            {
                currentInputStatus = 5;
                PlayerPrefs.SetInt("lightPuzzleStatus", 2);
                unlockedLightsMovement();
                audio.clip = successfulPress;
                GameObject btnPushAnim = GameObject.Find(buttonPushed);
                buttonPushAnim(btnPushAnim);
                audio.Play();
                Debug.Log("Unlock COMPLETE!");
                textScript.StartCoroutine("ButtonPress");

            }
        }
        else
        {
            currentInputStatus = 0;
            randomLightsMovement(false);
            audio.clip = buttonPress;
            GameObject btnPushAnim = GameObject.Find(buttonPushed);
            buttonPushAnim(btnPushAnim);
            audio.Play();
        }

    }
    public void randomLightsMovement(bool showText)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            //Text appears here about how the player doesn't know what to do with that yet.
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Renderer render = lights[i].GetComponent<Renderer>();
                render.material = onMaterial;
            }
            else
            {
                Renderer render = lights[i].GetComponent<Renderer>();
                render.material = offMaterial;
            }
            float textDisplayTime = 0f;
            {
                while (textDisplayTime < 5f && showText == true)
                {
                    if (!incorrectbuttonPush.enabled)
                    {
                        incorrectbuttonPush.enabled = true;
                    }
                    textDisplayTime += Time.deltaTime;
                }
            }
        }
    }
    public void unlockedLightsMovement()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            Renderer render = lights[i].GetComponent<Renderer>();
            render.material = onMaterial;
        }
    }
    public void buttonPushAnim(GameObject obj)
    {
        if (obj.name == ("Button1"))
        {
            button1.GetComponent<Animator>().Play("btnPush1", -1, 0f);
        }
        else if (obj.name == "Button2")
        {
            button2.GetComponent<Animator>().Play("btnPush2", -1, 0f);
        }
        else if (obj.name == "Button3")
        {
            button3.GetComponent<Animator>().Play("buttonPush", -1, 0f);
        }
        else if (obj.name == "Button4")
        {
            button4.GetComponent<Animator>().Play("btnPush4", -1, 0f);
        }
    }

}
