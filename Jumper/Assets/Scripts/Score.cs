﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static int scorevalue = 0;
    Text score;  
    // Use this for initialization
    void Start () {
        score = GetComponent<Text> ();
        score.text = "Puntaje: 0" ;

    }
	
	// Update is called once per frame
	void Update () {
		score.text = "Puntaje: " + scorevalue;

	}
}
