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
    void FixedUpdate()
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
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringssecondthirdfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();

                        }
                        else if (firstGameHit.name == "3ringSecThiFou" && secondGameHit.name != "1ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingsthirdfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringsecond, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringThiFou" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringSec")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopsecond, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringFou" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "1ringFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingsthirdfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringsecond, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringsecond, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringstopsecondthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "2ringThiFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringssecondthirdfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "3ringSecThiFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(fourrings, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringsecond, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecThi" && secondGameHit.name == "1ringFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringThi" && secondGameHit.name == "1ringTop")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringsecFou" && secondGameHit.name == "1ringTop")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringstopsecondfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();

                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "2ringSecThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringstopsecondthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "2ringSecFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringstopsecondfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecFou" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "1ringThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "1ringFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "3ringTopSecThi" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "2ringSecFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringstopsecondfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopFou" && secondGameHit.name == "1ringSec")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopsecond, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "2ringTopThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threeringstopsecondfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringSecFou" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringsecond, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringSec")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopsecond, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringTop" && secondGameHit.name == "1ringFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "1ringSec" && secondGameHit.name == "1ringFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(pole, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingssecondfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopSec" && secondGameHit.name == "1ringThi")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringsecond, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopthird, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "1ringFou")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(tworingstopfourth, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
                            checkPuzzle();
                        }
                        else if (firstGameHit.name == "2ringTopThi" && secondGameHit.name == "0ring")
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringthird, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(oneringtop, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;
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
