﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCombination : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GameObject.Find("DontDestroyOnLoad"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
