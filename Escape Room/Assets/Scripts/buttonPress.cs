using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseBookText()
    {
        GameObject raycast = GameObject.FindWithTag("Raycast");
        RaycastPlayer script = raycast.GetComponent<RaycastPlayer>();
        script.CloseBookText();
        if (script.GetTerminalEnabled())
        {
            script.CloseTerminalText();
        }
    }
    public void CloseTerminalText()
    {

    }
}
