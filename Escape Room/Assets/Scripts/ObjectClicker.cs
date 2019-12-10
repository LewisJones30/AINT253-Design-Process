using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    // Start is called before the first frame update
    void Start()
    {
        emissionColour.SetColor("_EmissionColor", Color.red);
        anim = tubeLight.GetComponent<Animator>();
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
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringThiFou" && secondGameHit.name == "0ring")
                        {
                            //oneringfourth, oneringthird
                            swapObjects(oneringfourth, oneringthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringSec")
                        {
                            //pole, tworingstopsecond
                            swapObjects(pole, tworingstopsecond);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringFou" && secondGameHit.name == "0ring")
                        {
                            //pole, oneringfourth
                            swapObjects(pole, oneringfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "0ring")
                        {
                            //pole, oneringthird
                            swapObjects(pole, oneringthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "1ringFou")
                        {
                            //pole, tworingsthirdfourth
                            swapObjects(pole, tworingsthirdfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "0ring")
                        {
                            //oneringsecond, oneringtop
                            swapObjects(oneringsecond, oneringtop);
                            checkPuzzle();

                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringThi")
                        {
                            //pole, tworingssecondthird
                            swapObjects(pole, tworingssecondthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "0ring")
                        {
                            //oneringthird, oneringsecond
                            swapObjects(oneringthird, oneringsecond);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringThi")
                        {
                            //pole, tworingstopthird
                            swapObjects(pole, tworingstopthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "0ring")
                        {
                            //pole, oneringtop
                            swapObjects(pole, oneringtop);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecThi")
                        {
                            //pole, threeringstopsecondthird
                            swapObjects(pole, threeringstopsecondthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                        {
                            //tworingssecondthird, oneringtop
                            swapObjects(tworingssecondthird, oneringtop);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "2ringThiFou")
                        {
                            //pole, threeringssecondthirdfourth
                            swapObjects(pole, threeringssecondthirdfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "3ringSecThiFou")
                        {
                            //pole, fourrings
                            swapObjects(pole, fourrings);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringFou")
                        {
                            //oneringsecond, tworingstopfourth
                            swapObjects(oneringsecond, tworingstopfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "0ring")
                        {
                            //oneringfourth, oneringtop
                            swapObjects(oneringfourth, oneringtop);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "1ringFou")
                        {
                            //oneringthird, tworingssecondfourth
                            swapObjects(oneringthird, tworingssecondfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "1ringTop")
                        {
                            //pole, tworingstopthird
                            swapObjects(pole, tworingstopthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringsecFou" && secondGameHit.name == "1ringTop")
                        {
                            //pole, threeringstopsecondfourth
                            swapObjects(pole, threeringstopsecondfourth);
                            checkPuzzle();

                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "2ringSecThi")
                        {
                            //oneringfourth, threeringstopsecondthird
                            swapObjects(oneringfourth, threeringstopsecondthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "2ringSecFou")
                        {
                            //oneringthird, threeringstopsecondfourth
                            swapObjects(oneringthird, threeringstopsecondfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecFou" && secondGameHit.name == "0ring")
                        {
                            //tworingssecondfourth, oneringtop
                            swapObjects(tworingssecondfourth, oneringtop);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "1ringThi")
                        {
                            //oneringfourth, tworingssecondthird
                            swapObjects(oneringfourth, tworingssecondthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "1ringFou")
                        {
                            //tworingssecondthird, tworingstopfourth
                            swapObjects(tworingssecondthird, tworingstopfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                        {
                            //tworingssecondthird, oneringtop
                            swapObjects(tworingssecondthird, oneringtop);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringThi")
                        {
                            //oneringfourth, tworingstopthird
                            swapObjects(oneringfourth, tworingstopthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecFou")
                        {
                            //pole, threeringstopsecondfourth
                            swapObjects(pole, threeringstopsecondfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringSec")
                        {
                            //oneringfourth, tworingstopsecond
                            swapObjects(oneringfourth, tworingstopsecond);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "2ringTopThi")
                        {
                            //oneringthird, threeringstopsecondfourth
                            swapObjects(oneringthird, threeringstopsecondfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "0ring")
                        {
                            //oneringsecond, oneringfourth
                            swapObjects(oneringfourth, oneringsecond);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringSec")
                        {
                            //oneringthird, tworingstopsecond
                            swapObjects(oneringthird, tworingstopsecond);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringFou")
                        {
                            //pole, tworingstopfourth
                            swapObjects(pole, tworingstopfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringFou")
                        {
                            //pole, tworingssecondfourth
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringThi")
                        {
                            //oneringsecond, tworingstopthird
                            swapObjects(oneringsecond, tworingstopthird);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringFou")
                        {
                            //oneringthird, tworingstopfourth
                            swapObjects(oneringthird, tworingstopfourth);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "0ring")
                        {
                            //oneringthird, oneringtop
                            swapObjects(oneringthird, oneringtop);
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "2ringThiFou")
                        {
                            swapObjects(oneringsecond, threeringstopthirdfourth);
                            checkPuzzle();
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
        Destroy(firstGameHit.transform.parent.gameObject);
        Instantiate(firstObject, firstObjectPos, transform.rotation);
        firstGameHit = null;
        Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
        Destroy(secondGameHit.transform.parent.gameObject);
        Instantiate(secondObject, secondObjectPos, transform.rotation);
        secondGameHit = null;
        checkPuzzle();
    }
    public void checkPuzzle()
    {
        RaycastHit hit;

        if (Physics.Raycast(checkPuzzleObj.gameObject.transform.position, Vector3.back, out hit, 10.0f))
        {
            if (hit.transform.gameObject.name == "4ring")
            {
                StartCoroutine("completedPuzzle");

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
    IEnumerator completedPuzzle()
    {
        poleText.text = "Puzzle complete!";
        Debug.Log("Puzzle complete!");
        emissionColour.SetColor("_EmissionColor", Color.green);
        anim.SetTrigger("completedPuzzle");
        PlayerPrefs.SetInt("puzzle1Complete", 1);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameWinScene");
    }
}


