using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public GameObject prefab;
    private Transform m_transform;
    private GameObject[] m_array;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
        InstantiateTest();
        m_array = new GameObject[1000];
    }

    // Update is called once per frame
    void transformTest()
    {
        for (int i = 0; i < 10000; i++)
        {
            m_transform.position = Vector3.zero;
        }
    }
     void Update()
    {
        transformTest();
        objectAllocation();
        InstantiateTest();
    }
    void objectAllocation()
    {
        for (int i = 0; i < 10000; i++)
        {
            int firstInt = 1;
            firstInt++;
            int secondInt = firstInt;

            complexObject tempObject = new complexObject();
            complexObject tempObject1 = new complexObject();
            complexObject tempObject2 = new complexObject();
        }

    }
    void InstantiateTest()
    {
        for (int i = 0; i < m_array.Length; i++)
        {
            m_array[i] = Instantiate(prefab);
            m_array[i].transform.position = new Vector3(1, 2, 3);
            Destroy(m_array[i]);
        }
    }
    private float[] RandomValues(int _numOfValues)
    {
        var numberList = new float[_numOfValues];
        for (int i = 0; i < _numOfValues; i++)
        {
            numberList[i] = Random.Range(1, 100);
        }
        return numberList;
    }
}
