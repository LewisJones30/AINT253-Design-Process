using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ObjectClicker : MonoBehaviour
{
    GameObject firstGameHit, secondGameHit;
    public Text poleText;
    public GameObject checkPuzzleObj, tubeLight;
    public GameObject fourrings, threeringstopsecondfourth, threeringstopsecondthird, threeringstopthirdfourth, threeringssecondthirdfourth,
        tworingssecondthird, tworingsthirdfourth, tworingstopfourth, tworingstopsecond, tworingstopthird, tworingssecondfourth,
        oneringsecond, oneringthird, oneringfourth, oneringtop,
        pole;
    public Material emissionColour;
    Animator anim;
    public Timer timeScript;
    public AudioSource audio;

    //SerializeField variables
    [SerializeField]
    GameObject obj1;
    [SerializeField]
    GameObject obj2;
    [SerializeField]
    GameObject obj3;
    Vector3 TowerSlot1Coordinates = new Vector3(6.671f, 8.031f, 15.56f);
    Vector3 TowerSlot2Coordinates = new Vector3(8.204f, 8.031f, 15.56f);
    Vector3 TowerSlot3Coordinates = new Vector3(9.94f, 8.031f, 15.56f);
    //Private variables
    Stack stack0 = new Stack();
    Stack stack1 = new Stack();
    Stack stack2 = new Stack();
    const string firstPoleChosen = "Choose a pole to move counter to...";
    const string errorText = "Move not possible! Choose a pole.";
    const string swapComplete = "Swap completed. Choose a pole.";

    // Start is called before the first frame update
    void Start()
    {
        emissionColour.SetColor("_EmissionColor", Color.red);
        anim = tubeLight.GetComponent<Animator>();
        stack0.Push(4);
        stack0.Push(3);
        stack0.Push(2);
        stack0.Push(1);
        ReRenderObjects();
    }
    void CheckIfValidSwap(Stack stack1, Stack stack2)
    {
        firstGameHit = null;
        secondGameHit = null;
        int peekValue1;
        int peekValue2;
        if (stack1.Count == 0)
        {
            peekValue1 = 0;
        }
        else
        {
            peekValue1 = Convert.ToInt32(stack1.Peek());
        }
        if (stack2.Count == 0)
        {
            peekValue2 = 0;
        }
        else
        {
            peekValue2 = Convert.ToInt32(stack2.Peek());
        }
        if (peekValue2 == 0) //If the chosen pole is an empty pole, it is an allowed move.
        {
            object poppedValue1 = stack1.Pop();
            stack2.Push(poppedValue1);
            ReRenderObjects();
            CheckPuzzle();
            return;
        }
        if (peekValue1 < peekValue2) //otherwise, the top value in first selection must be smaller than the second selection's top value.
        {
            object poppedValue1 = stack1.Pop();
            stack2.Push(poppedValue1);
            ReRenderObjects();
            CheckPuzzle();
        }
        else
        {
            poleText.text = "Move not possible! Choose a pole.";
        }
    }

    void ReRenderObjects()
    {
        int stack1Count = stack0.Count;
        int stack2Count = stack1.Count;
        int stack3Count = stack2.Count;
        //Destroy all the current poles to be re-rendered.
        GameObject[] objs = GameObject.FindGameObjectsWithTag("0");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }

        GameObject[] objs1 = GameObject.FindGameObjectsWithTag("1");
        foreach (GameObject obj in objs1)
        {
            Destroy(obj);
        }
        GameObject[] objs2 = GameObject.FindGameObjectsWithTag("2");
        foreach (GameObject obj in objs2)
        {
            Destroy(obj);
        }
        GameObject[] objs3 = GameObject.FindGameObjectsWithTag("3");
        foreach (GameObject obj in objs3)
        {
            Destroy(obj);
        }
        GameObject[] objs4 = GameObject.FindGameObjectsWithTag("4");
        foreach (GameObject obj in objs4)
        {
            Destroy(obj);
        }
        Render(stack1Count, TowerSlot1Coordinates, stack0, "0");
        Render(stack2Count, TowerSlot2Coordinates, stack1, "1");
        Render(stack3Count, TowerSlot3Coordinates, stack2, "2");
    }
    void Render(int switchVal, Vector3 coordinates, Stack stack, string name)
    {
        switch (switchVal) //Switch based on the count of each stack.
        {
            case 0:
                { 
                    var newObj = GameObject.Instantiate(pole, coordinates, transform.rotation);
                    newObj.tag = "1";
                    newObj.name = name;
                    break;
                }
            case 1:
                {
                    int topVal = Convert.ToInt32(stack.Peek());
                    if (topVal == 1)
                    {
                        var newObj = GameObject.Instantiate(oneringtop, coordinates, transform.rotation);
                        newObj.tag = "1";
                        newObj.name = name;
                        break;
                    }
                    else if (topVal == 2)
                    {
                        var newObj = GameObject.Instantiate(oneringsecond, coordinates, transform.rotation);
                        newObj.tag = "1";
                        newObj.name = name;
                        break;
                    }
                    else if (topVal == 3)
                    {
                        var newObj = GameObject.Instantiate(oneringthird, coordinates, transform.rotation);
                        newObj.tag = "1";
                        newObj.name = name;
                        break;
                    }
                    else
                    {
                        var newObj = GameObject.Instantiate(oneringfourth, coordinates, transform.rotation);
                        newObj.tag = "1";
                        newObj.name = name;
                        break;
                    }

                }
            case 2:
                {
                    int topVal = Convert.ToInt32(stack.Peek());
                    if (topVal == 1)
                    {
                        stack.Pop();
                        int topVal2 = Convert.ToInt32(stack.Peek());
                        stack.Push(topVal);
                        if (topVal2 == 2)
                        {
                            var newObj = GameObject.Instantiate(tworingstopsecond, coordinates, transform.rotation);
                            newObj.tag = "2";
                            newObj.name = name;
                            break;
                        }
                        else if (topVal2 == 3)
                        {
                            var newObj = GameObject.Instantiate(tworingstopthird, coordinates, transform.rotation);
                            newObj.tag = "2";
                            newObj.name = name;
                            break;
                        }
                        else
                        {
                            var newObj = GameObject.Instantiate(tworingstopfourth, coordinates, transform.rotation);
                            newObj.tag = "2";
                            newObj.name = name;
                            break;
                        }
                    }
                    else if (topVal == 2)
                    {
                        stack.Pop();
                        int topVal2 = Convert.ToInt32(stack.Peek());
                        stack.Push(topVal);
                        if (topVal2 == 3)
                        {
                            var newObj = GameObject.Instantiate(tworingssecondthird, coordinates, transform.rotation);
                            newObj.tag = "2";
                            newObj.name = name;
                            break;
                        }
                        else
                        {
                            var newObj = GameObject.Instantiate(tworingssecondfourth, coordinates, transform.rotation);
                            newObj.tag = "2";
                            newObj.name = name;
                            break;
                        }
                    }
                    else if (topVal == 3)
                    {
                        var newObj = GameObject.Instantiate(tworingsthirdfourth, coordinates, transform.rotation);
                        newObj.tag = "2";
                        newObj.name = name;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            case 3:
                {
                    int topVal = Convert.ToInt32(stack.Peek());
                    if (topVal == 1)
                    {
                        stack.Pop();
                        int topVal2 = Convert.ToInt32(stack.Peek());
                        stack.Push(topVal);
                        if (topVal2 == 2)
                        {
                            stack.Pop();
                            stack.Pop();
                            int topVal3 = Convert.ToInt32(stack.Peek());
                            stack.Push(topVal2);
                            stack.Push(topVal);
                            //Check if 3 or 4.
                            if (topVal3 == 3)
                            {
                                var newObj = GameObject.Instantiate(threeringstopsecondthird, coordinates, transform.rotation);
                                newObj.tag = "3";
                                newObj.name = name;
                                break;
                            }
                            else
                            {
                                var newObj = GameObject.Instantiate(threeringstopsecondfourth, coordinates, transform.rotation);
                                newObj.tag = "3";
                                newObj.name = name;
                                break;
                            }
                        }
                        else //Value must be 3 due to size of stack.
                        {
                            var newObj = GameObject.Instantiate(threeringstopthirdfourth, coordinates, transform.rotation);
                            newObj.tag = "3";
                            newObj.name = name;
                            break;
                        }
                    }
                    else //Due to the size, the value can only be 1 or 2.
                    {
                        var newObj = GameObject.Instantiate(threeringssecondthirdfourth, coordinates, transform.rotation);
                        newObj.tag = "3";
                        newObj.name = name;
                        break;
                    }
                }
            case 4:
                {
                    var newObj = GameObject.Instantiate(fourrings, coordinates, transform.rotation);
                    newObj.tag = "4";
                    newObj.name = name;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Fire a ray at the cursor location
        Debug.DrawRay(checkPuzzleObj.gameObject.transform.position, Vector3.back, Color.red, 100.0f);
        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, 50.0f)) //Distance of 50, will probably be changed in the future
            {
                if (hit.transform.gameObject.name == "Cube" || hit.transform.gameObject.name == "completionCheckObj" || hit.transform.gameObject.name == "")
                {
                    return;
                }
                if (hit.transform != null)
                {
                    audio.Play();
                    if (firstGameHit == null)
                    {
                        firstGameHit = hit.transform.gameObject;
                        poleText.text = firstPoleChosen;
                    }
                    else
                    {
                        secondGameHit = hit.transform.gameObject;
                        Debug.Log(secondGameHit.transform.parent.name + "second choice");
                        poleText.text = swapComplete;
                        if (firstGameHit.transform.parent.name == secondGameHit.transform.parent.name)
                        {
                            poleText.text = errorText;
                            firstGameHit = null;
                            secondGameHit = null;
                            return;
                        }
                        if (firstGameHit.transform.parent.name == "0")
                        {
                            if (secondGameHit.transform.parent.name == "1")
                            {
                                CheckIfValidSwap(stack0, stack1);
                            }
                            else 
                            { 
                                CheckIfValidSwap(stack0, stack2); 
                            }
                        }
                        else if (firstGameHit.transform.parent.name == "1")
                        {
                            if (secondGameHit.transform.parent.name == "2")
                            {
                                CheckIfValidSwap(stack1, stack2);
                            }
                            else 
                            {
                                CheckIfValidSwap(stack1, stack0);
                            }
                        }
                        else if (firstGameHit.transform.parent.name == "2")
                        {
                            if (secondGameHit.transform.parent.name == "0")
                            {
                                CheckIfValidSwap(stack2, stack0);
                            }
                            else
                            {
                                CheckIfValidSwap(stack2, stack1);
                            }
                        }
                        else
                        {
                            firstGameHit = null;
                            secondGameHit = null;

                        }

                        //Check code here
                    //    if (firstGameHit.name == "4ring" && secondGameHit.name == "0ring")
                    //    {
                            
                    //        //Instantiate(threeringssecondthirdfourth, firstObjectPos, transform.rotation);
                    //        //Instantiate(oneringtop, secondObjectPos, transform.rotation);;

                    //    }
                    //    else if (firstGameHit.name == "3ringSecThiFou" && secondGameHit.name != "1ring" && secondGameHit.name != "3ringSecThiFou")
                    //    {
                    //        //tworingsthirdfourth, oneringsecond
                    //        swapObjects(tworingsthirdfourth, oneringsecond);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringThiFou" && secondGameHit.name == "0ring")
                    //    {
                    //        //oneringfourth, oneringthird
                    //        swapObjects(oneringfourth, oneringthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringSec")
                    //    {
                    //        //pole, tworingstopsecond
                    //        swapObjects(pole, tworingstopsecond);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringFou" && secondGameHit.name == "0ring")
                    //    {
                    //        //pole, oneringfourth
                    //        swapObjects(pole, oneringfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "0ring")
                    //    {
                    //        //pole, oneringthird
                    //        swapObjects(pole, oneringthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "1ringFou")
                    //    {
                    //        //pole, tworingsthirdfourth
                    //        swapObjects(pole, tworingsthirdfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "0ring")
                    //    {
                    //        //oneringsecond, oneringtop
                    //        swapObjects(oneringsecond, oneringtop);
                    //        checkPuzzle();

                    //    }
                    //    else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringThi")
                    //    {
                    //        //pole, tworingssecondthird
                    //        swapObjects(pole, tworingssecondthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "0ring")
                    //    {
                    //        //oneringthird, oneringsecond
                    //        swapObjects(oneringthird, oneringsecond);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringThi")
                    //    {
                    //        //pole, tworingstopthird
                    //        swapObjects(pole, tworingstopthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "0ring")
                    //    {
                    //        //pole, oneringtop
                    //        swapObjects(pole, oneringtop);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecThi")
                    //    {
                    //        //pole, threeringstopsecondthird
                    //        swapObjects(pole, threeringstopsecondthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                    //    {
                    //        //tworingssecondthird, oneringtop
                    //        swapObjects(tworingssecondthird, oneringtop);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "2ringThiFou")
                    //    {
                    //        //pole, threeringssecondthirdfourth
                    //        swapObjects(pole, threeringssecondthirdfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "3ringSecThiFou")
                    //    {
                    //        //pole, fourrings
                    //        swapObjects(pole, fourrings);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringFou")
                    //    {
                    //        //oneringsecond, tworingstopfourth
                    //        swapObjects(oneringsecond, tworingstopfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "0ring")
                    //    {
                    //        //oneringfourth, oneringtop
                    //        swapObjects(oneringfourth, oneringtop);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "1ringFou")
                    //    {
                    //        //oneringthird, tworingssecondfourth
                    //        swapObjects(oneringthird, tworingssecondfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringsecFou" && secondGameHit.name == "1ringTop")
                    //    {
                    //        //pole, threeringstopsecondfourth
                    //        swapObjects(pole, threeringstopsecondfourth);
                    //        checkPuzzle();

                    //    }
                    //    else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "2ringSecThi")
                    //    {
                    //        //oneringfourth, threeringstopsecondthird
                    //        swapObjects(oneringfourth, threeringstopsecondthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "2ringSecFou")
                    //    {
                    //        //oneringthird, threeringstopsecondfourth
                    //        swapObjects(oneringthird, threeringstopsecondfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "3ringTopSecFou" && secondGameHit.name == "0ring")
                    //    {
                    //        //tworingssecondfourth, oneringtop
                    //        swapObjects(tworingssecondfourth, oneringtop);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "1ringThi")
                    //    {
                    //        //oneringfourth, tworingssecondthird
                    //        swapObjects(oneringfourth, tworingssecondthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "1ringFou")
                    //    {
                    //        //tworingssecondthird, tworingstopfourth
                    //        swapObjects(tworingssecondthird, tworingstopfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                    //    {
                    //        //tworingssecondthird, oneringtop
                    //        swapObjects(tworingssecondthird, oneringtop);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringThi")
                    //    {
                    //        //oneringfourth, tworingstopthird
                    //        swapObjects(oneringfourth, tworingstopthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecFou")
                    //    {
                    //        //pole, threeringstopsecondfourth
                    //        swapObjects(pole, threeringstopsecondfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringSec")
                    //    {
                    //        //oneringfourth, tworingstopsecond
                    //        swapObjects(oneringfourth, tworingstopsecond);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "2ringTopThi")
                    //    {
                    //        //oneringthird, threeringstopsecondfourth
                    //        swapObjects(oneringthird, threeringstopsecondfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "0ring")
                    //    {
                    //        //oneringsecond, oneringfourth
                    //        swapObjects(oneringfourth, oneringsecond);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringSec")
                    //    {
                    //        //oneringthird, tworingstopsecond
                    //        swapObjects(oneringthird, tworingstopsecond);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringFou")
                    //    {
                    //        //pole, tworingstopfourth
                    //        swapObjects(pole, tworingstopfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringFou")
                    //    {
                    //        swapObjects(pole, tworingssecondfourth);
                    //        checkPuzzle();
                    //        //pole, tworingssecondfourth
                    //    }
                    //    else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringThi")
                    //    {
                    //        //oneringsecond, tworingstopthird
                    //        swapObjects(oneringsecond, tworingstopthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringFou")
                    //    {
                    //        //oneringthird, tworingstopfourth
                    //        swapObjects(oneringthird, tworingstopfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "0ring")
                    //    {
                    //        //oneringthird, oneringtop
                    //        swapObjects(oneringthird, oneringtop);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "2ringThiFou")
                    //    {
                    //        swapObjects(oneringsecond, threeringstopthirdfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringFou")
                    //    {
                    //        swapObjects(oneringsecond, tworingstopfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringThiFou")
                    //    {
                    //        swapObjects(pole, threeringstopthirdfourth);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "3ringTopThiFou" && secondGameHit.name == "0ring")
                    //    {
                    //        swapObjects(tworingsthirdfourth, oneringtop);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "3ringTopThiFou" && secondGameHit.name == "1ringSec")
                    //    {
                    //        swapObjects(tworingsthirdfourth, tworingstopsecond);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "3ringTopSecFou" && secondGameHit.name == "1ringThi")
                    //    {
                    //        swapObjects(tworingssecondfourth, tworingstopthird);
                    //        checkPuzzle();
                    //    }
                    //    else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "0ring")
                    //    {
                    //        swapObjects(pole, oneringsecond);
                    //        checkPuzzle();
                    //    }
                    //    else
                    //    {
                    //        firstGameHit = null;
                    //        secondGameHit = null;
                    //        poleText.text = "Invalid choice. Choose a pole.";
                    //    }
                    }
                }
            }
        }
    }

    public void CheckPuzzle()
    {
        if (stack2.Count == 4)
        {
            StartCoroutine("CompletedPuzzle");
        }
    }
    IEnumerator CompletedPuzzle()
    {
        poleText.text = "Puzzle complete!";
        Debug.Log("Puzzle complete!");
        emissionColour.SetColor("_EmissionColor", Color.green);
        anim.SetTrigger("completedPuzzle");
        PlayerPrefs.SetFloat("timeRemaining", timeScript.GetTimeRemaining());
        PlayerPrefs.SetInt("puzzle1Complete", 1);
        yield return new WaitForSeconds(2.5f);
        poleText.text = "Returning to main room...";
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("SampleScene");

    }
}


