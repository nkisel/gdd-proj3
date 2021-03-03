using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetColliderScript : MonoBehaviour {

	// Returns whether the obj is a floor, platform, or wall
	bool isFloor(GameObject obj) {
		// return obj.layer == LayerMask.NameToLayer ("Floor");
		return true;
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (isFloor(c.collider.gameObject)) GetComponentInParent<PlayerController>().feetContact
= true;
	}

	void OnCollisionExit2D(Collision2D c) {
		if (isFloor(c.collider.gameObject)) GetComponentInParent<PlayerController>().feetContact
= false;
	}

}
