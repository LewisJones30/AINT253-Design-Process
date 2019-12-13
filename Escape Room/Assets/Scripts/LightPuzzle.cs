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
    public void notUnlockedButtonPress() //This is launched when the player has not unlocked the puzzle yet to prevent interaction.

    {
        for (int i = 0; i < lights.Length; i++)
        {
            //Text appears here about how the player doesn't know what to do with that yet.
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
    public void UnlockedButtonPress() //This is executed when the player has unlocked the puzzle. Once they input the correct code, the door will open and the player is able to escape the room.
    {
        //Button solution is... 4, 2, 3, 1, 4
        //Random light switching but record the order they pressed it in
        //Five lights on the top will indicate if it has been completed in the right order.
        //Check status of the five lights on top.
    }
}
