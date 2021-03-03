﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movespeed;
	public float maxspeed;
	public float jumpforce;

	int FloorLayer;

	Rigidbody2D playerRB;

	public bool feetContact;
	public bool leftContact;
	public bool rightContact;

	void Awake() {
		playerRB = gameObject.GetComponent<Rigidbody2D>();
		feetContact = false;
		leftContact = false;
		rightContact = false;
	}

	void Update () {
		float MoveHor = Input.GetAxisRaw ("Horizontal");
		Vector2 movement = new Vector2 (MoveHor * movespeed, 0);
		movement = movement * Time.deltaTime;

		playerRB.AddForce(movement);
		if (playerRB.velocity.x > maxspeed) {
			playerRB.velocity = new Vector2(Mathf.Lerp(playerRB.velocity.x, maxspeed, 0.6f), playerRB.velocity.y);
		}
		if (playerRB.velocity.x < -maxspeed) {
			playerRB.velocity = new Vector2(Mathf.Lerp(playerRB.velocity.x, -maxspeed, 0.6f), playerRB.velocity.y);
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (feetContact)
            {
				playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
				playerRB.AddForce(new Vector2(0, jumpforce));

			}
			else if (leftContact)
            {
				playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
				playerRB.AddForce(new Vector2(jumpforce, jumpforce));
			}
			else if (rightContact)
			{
				playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
				playerRB.AddForce(new Vector2(-jumpforce, jumpforce));
			}
		}

	}

	bool canJump() {
		return feetContact || leftContact;
		//TASK 2
	}
}
