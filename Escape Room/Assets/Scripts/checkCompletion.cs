using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class checkCompletion : MonoBehaviour
{
    ObjectClicker script;
    public GameObject objectForScript;
    // Start is called before the first frame update
    private void Start()
    {
        script = objectForScript.GetComponent<ObjectClicker>();
    }
    public void checkPuzzle()
    {
        script.checkPuzzle();
    }
}
