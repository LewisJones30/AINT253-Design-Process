using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void closeBookText()
    {
        GameObject raycast = GameObject.Find("raycast");
        RaycastPlayer script = raycast.GetComponent<RaycastPlayer>();
        script.closeBookText();
    }
}
