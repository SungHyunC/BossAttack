﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public void ChangeScene()
    {
        
        Application.LoadLevel("Character");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }
}
