using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class checkCompletion : MonoBehaviour
{
    public Text UIText;
    public Light completionLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void checkPuzzle()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 10.0f))
        {
            if (hit.transform.gameObject.name == "4ring")
            {

                StartCoroutine(PuzzleComplete());

            }
            else
            {
                UIText.text = "Puzzle not complete.";
                Debug.Log(hit.transform.gameObject.name);
            }
        }
        else
        {
            UIText.text = "Error has occured!";
        }
    }
    IEnumerator PuzzleComplete()
    {
        UIText.text = "Puzzle complete!";
        Debug.Log("Puzzle complete!");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(""); //Load completion scene.
    }
}
