using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float sensitivityX;
    [SerializeField]
    float sensitivityY;

    float rotationX = 0f;
    float rotationY = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, -90, 90);
        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
