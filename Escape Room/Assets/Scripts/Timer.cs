using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Adapted from AINT254 Timer Script.
 */
public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public Text timeLeftText;
    public bool timeTicking = true;
    CanvasGroup group;
    public Canvas canvas;
    public Text GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        group = canvas.GetComponent<CanvasGroup>();
        timeLeftText.color = Color.green;
        group.alpha = 0;
        GameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTicking == true)
        {
            timeLeft -= Time.deltaTime; //This is used as the time remaining counter.
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
            string timeLeftString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timeLeftText.text = timeLeftString;

            if (timeLeft < 300) //5 Minutes remaining
            {
                timeLeftText.color = Color.yellow;
                if (timeLeft < 60) // 1 Minute remaining
                {
                    timeLeftText.color = Color.red;
                    if (timeLeft < 30)
                    {
                        GameOverText.enabled = true;
                        GameOverText.text = "Is this the end? I don't feel right..";
                        if (seconds % 2 == 0)
                        {
                            timeLeftText.color = Color.white;
                        }
                    }
                }
            }
            if (timeLeft < 0)
            {
                //Code when time ends to start explosion and player fainting sequence.
                freezeTime();
                GameOverText.enabled = true;

                GameOverText.text = "The world around me suddenly turns black...";
                timeLeftText.text =string.Format("{0:00}:{1:00}", 0, 0); 

                StartCoroutine("Fade");
                


            }
        }
        else
        {
            return;
        }


    }
    public float getTimeRemaining()
    {
        return timeLeft;
    }
    public void setTimeRemaining(float time)
    {
        timeLeft = time; 
    }
    public void freezeTime()
    {
        timeTicking = false;
    }
    public void resumeTime()
    {
        timeTicking = true;
    }
    IEnumerator Fade()
    {
        while (group.alpha < 1)
        {
            group.alpha += Time.deltaTime / 2;
            yield return  null;
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameLossScene");
    }
}

