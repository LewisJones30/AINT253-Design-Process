using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towersScene : MonoBehaviour
{
    public Timer timeScript;
    // Start is called before the first frame update
    void Start()
    {
        float timeRemaining = PlayerPrefs.GetFloat("timeRemaining");
        Debug.Log("Towers scene time remaining: " + timeRemaining);
        timeScript.FreezeTime();
        timeScript.SetTimeRemaining(timeRemaining);
        timeScript.ResumeTime();
        //Initialise variables here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
