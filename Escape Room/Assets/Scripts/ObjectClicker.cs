using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectClicker : MonoBehaviour
{
    GameObject firstGameHit, secondGameHit;
    public Text poleText;
    public GameObject fourrings, threerings, tworings, onering;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Fire a ray at the cursor location

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, 50.0f)) //Distance of 50, will probably be changed in the future
            {
                if (hit.transform != null)
                {
                    print(hit.transform.gameObject);
                    if (firstGameHit == null)
                    {
                        firstGameHit = hit.transform.gameObject;
                        poleText.text = firstGameHit.name + " is selected. Choose a second pole." ;
                    }
                    else
                    {
                        secondGameHit = hit.transform.gameObject;
                        //Check code here
                        if (firstGameHit.name == "4ring" && secondGameHit.name == "0ring") 
                        {
                            Vector3 firstObjectPos = new Vector3(firstGameHit.transform.parent.gameObject.transform.position.x, firstGameHit.transform.parent.gameObject.transform.position.y, firstGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(threerings, firstObjectPos, transform.rotation);
                            Destroy(firstGameHit.transform.parent.gameObject);
                            firstGameHit = null;
                            Vector3 secondObjectPos = new Vector3(secondGameHit.transform.parent.gameObject.transform.position.x, secondGameHit.transform.parent.gameObject.transform.position.y, secondGameHit.transform.parent.gameObject.transform.position.z);
                            Instantiate(onering, secondObjectPos, transform.rotation);
                            Destroy(secondGameHit.transform.parent.gameObject);
                            secondGameHit = null;

                        }
                        // else if (firstGameHit.name == "1ring" && secondGameHit == "")
                    }
                }
            }
        }
    }
}
