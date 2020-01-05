﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneNav : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void backtoMainRoom()
    {
        PlayerPrefs.SetInt("puzzle1Complete", 2);
        SceneManager.LoadScene("SampleScene");

    }
    public void finishGame()
    {
        SceneManager.LoadScene("GameWinScene");
    }
}
