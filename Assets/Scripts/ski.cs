﻿using UnityEngine;
using System.Collections;

public class ski : MonoBehaviour {

	public float Speed;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal , 0.0f, moveVertical);

		rb.AddForce(movement * Speed);


	}
}
