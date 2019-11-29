using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ObjectClicker : MonoBehaviour
{
    GameObject firstGameHit, secondGameHit;
    public Text poleText;
    public GameObject checkPuzzleObj;
    public GameObject fourrings, threeringstopsecondfourth, threeringstopsecondthird, threeringstopthirdfourth, threeringssecondthirdfourth,
        tworingssecondthird, tworingsthirdfourth, tworingstopfourth, tworingstopsecond, tworingstopthird, tworingssecondfourth,
        oneringsecond, oneringthird, oneringfourth, oneringtop,
        pole;
    public Light completionLight;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    print(hit.transform.gameObject);
                    if (firstGameHit == null)
                    {
                        firstGameHit = hit.transform.gameObject;
                        poleText.text = firstGameHit.name + " is selected. Choose a second pole.";
                    }
                    else
                    {
                        secondGameHit = hit.transform.gameObject;
                        poleText.text = "Choose a pole.";
                        //Check code here
                        if (firstGameHit.name == "4ring" && secondGameHit.name == "0ring")
                        {
                            swapObjects(threeringssecondthirdfourth, oneringtop);
                            //Instantiate(threeringssecondthirdfourth, firstObjectPos, transform.rotation);
                            //Instantiate(oneringtop, secondObjectPos, transform.rotation);;

                        }
                        else if (firstGameHit.name == "3ringSecThiFou" && secondGameHit.name != "1ring")
                        {
                            //tworingsthirdfourth, oneringsecond
                            swapObjects(tworingsthirdfourth, oneringsecond);
                        }
                        else if (firstGameHit.name == "2ringThiFou" && secondGameHit.name == "0ring")
                        {
                            //oneringfourth, oneringthird
                            swapObjects(oneringfourth, oneringthird);
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringSec")
                        {
                            //pole, tworingstopsecond
                            swapObjects(pole, tworingstopsecond);
                        }
                        else if (firstGameHit.name == "1ringFou" && secondGameHit.name == "0ring")
                        {
                            //pole, oneringfourth
                            swapObjects(pole, oneringfourth);
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "0ring")
                        {
                            //pole, oneringthird
                            swapObjects(pole, oneringthird);
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "1ringFou")
                        {
                            //pole, tworingsthirdfourth
                            swapObjects(pole, tworingsthirdfourth);
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "0ring")
                        {
                            //oneringsecond, oneringtop
                            swapObjects(oneringsecond, oneringtop);

                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringThi")
                        {
                            //pole, tworingssecondthird
                            swapObjects(pole, tworingssecondthird);
                        }
                        else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "0ring")
                        {
                            //oneringthird, oneringsecond
                            swapObjects(oneringthird, oneringsecond);
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringThi")
                        {
                            //pole, tworingstopthird
                            swapObjects(pole, tworingstopthird);
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "0ring")
                        {
                            //pole, oneringtop
                            swapObjects(pole, oneringtop);
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecThi")
                        {
                            //pole, threeringstopsecondthird
                            swapObjects(pole, threeringstopsecondthird);
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                        {
                            //tworingssecondthird, oneringtop
                            swapObjects(tworingssecondthird, oneringtop);
                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "2ringThiFou")
                        {
                            //pole, threeringssecondthirdfourth
                            swapObjects(pole, threeringssecondthirdfourth);
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "3ringSecThiFou")
                        {
                            //pole, fourrings
                            swapObjects(pole, fourrings);
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringFou")
                        {
                            //oneringsecond, tworingstopfourth
                            swapObjects(oneringsecond, tworingstopfourth);
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "0ring")
                        {
                            //oneringfourth, oneringtop
                            swapObjects(oneringfourth, oneringtop);
                        }
                        else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "1ringFou")
                        {
                            //oneringthird, tworingssecondfourth
                            swapObjects(oneringthird, tworingssecondfourth);
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "1ringTop")
                        {
                            //pole, tworingstopthird
                            swapObjects(pole, tworingstopthird);
                        }
                        else if (firstGameHit.name == "2ringsecFou" && secondGameHit.name == "1ringTop")
                        {
                            //pole, threeringstopsecondfourth
                            swapObjects(pole, threeringstopsecondfourth);

                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "2ringSecThi")
                        {
                            //oneringfourth, threeringstopsecondthird
                            swapObjects(oneringfourth, threeringstopsecondthird);
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "2ringSecFou")
                        {
                            //oneringthird, threeringstopsecondfourth
                            swapObjects(oneringthird, threeringstopsecondfourth);
                        }
                        else if (firstGameHit.name == "3ringTopSecFou" && secondGameHit.name == "0ring")
                        {
                            //tworingssecondfourth, oneringtop
                            swapObjects(tworingssecondfourth, oneringtop);
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "1ringThi")
                        {
                            //oneringfourth, tworingssecondthird
                            swapObjects(oneringfourth, tworingssecondthird);
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "1ringFou")
                        {
                            //tworingssecondthird, tworingstopfourth
                            swapObjects(tworingssecondthird, tworingstopfourth);
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                        {
                            //tworingssecondthird, oneringtop
                            swapObjects(tworingssecondthird, oneringtop);
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringThi")
                        {
                            //oneringfourth, tworingstopthird
                            swapObjects(oneringfourth, tworingstopthird);
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecFou")
                        {
                            //pole, threeringstopsecondfourth
                            swapObjects(pole, threeringstopsecondfourth);
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringSec")
                        {
                            //oneringfourth, tworingstopsecond
                            swapObjects(oneringfourth, tworingstopsecond);
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "2ringTopThi")
                        {
                            //oneringthird, threeringstopsecondfourth
                            swapObjects(oneringthird, threeringstopsecondfourth);
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "0ring")
                        {
                            //oneringsecond, oneringfourth
                            swapObjects(oneringfourth, oneringsecond);
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringSec")
                        {
                            //oneringthird, tworingstopsecond
                            swapObjects(oneringthird, tworingstopsecond);
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringFou")
                        {
                            //pole, tworingstopfourth
                            swapObjects(pole, tworingstopfourth);
                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringFou")
                        {
                            //pole, tworingssecondfourth
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringThi")
                        {
                            //oneringsecond, tworingstopthird
                            swapObjects(oneringsecond, tworingstopthird);
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringFou")
                        {
                            //oneringthird, tworingstopfourth
                            swapObjects(oneringthird, tworingstopfourth);
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "0ring")
                        {
                            //oneringthird, oneringtop
                            swapObjects(oneringthird, oneringtop);
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "2ringThiFou")
                        {
                            swapObjects(oneringsecond, threeringstopthirdfourth);
                        }
                        else
                        {
                            firstGameHit = null;
                            secondGameHit = null;
                            poleText.text = "Invalid choice. Choose a pole.";
                        }
                    }
                }
            }
        }
    }

    void swapObjects(GameObject firstObject, GameObject secondObject)
    {
        Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
        Instantiate(firstObject, firstObjectPos, transform.rotation);
        Destroy(firstGameHit.transform.parent.gameObject);
        firstGameHit = null;
        Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
        Instantiate(secondObject, secondObjectPos, transform.rotation);
        Destroy(secondGameHit.transform.parent.gameObject);
        secondGameHit = null;
        checkPuzzle();
    }
    void checkPuzzle()
    {
            RaycastHit hit;

            if (Physics.Raycast(checkPuzzleObj.gameObject.transform.position, Vector3.back, out hit, 10.0f))
            {
                if (hit.transform.gameObject.name == "4ring")
                {
                    poleText.text = "Puzzle complete!";
                    Debug.Log("Puzzle complete!");
                    completionLight.color = Color.green;
                SceneManager.LoadScene("GameWinScene");

                }
                else
                {
                    //poleText.text = "Puzzle not complete.";
                    Debug.Log(hit.transform.gameObject.name + "from check cube");
                }
            }
            else
            {
                poleText.text = "Error has occured!";
            }
        }
    }


