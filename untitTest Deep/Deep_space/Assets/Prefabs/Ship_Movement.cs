﻿using UnityEngine;
using System.Collections;

public class Ship_Movement : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3( -Input.GetAxis("Vertical"), 0,Input.GetAxis("Horizontal"))  * Time.deltaTime * speed);

	}
}
