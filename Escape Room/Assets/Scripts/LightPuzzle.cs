using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lights = new GameObject[24];
    public Material onMaterial;
    public Material offMaterial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            notUnlockedButtonPress();
        }
    }
    public void notUnlockedButtonPress()

    {
        for (int i = 0; i < lights.Length; i++)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Renderer render = lights[i].GetComponent<Renderer>();
                render.material = onMaterial;
            }
            else
            {
                Renderer render = lights[i].GetComponent<Renderer>();
                render.material = offMaterial;
            }
        }
    }
}
