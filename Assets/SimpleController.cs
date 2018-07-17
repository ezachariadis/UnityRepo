using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour {
	float x;
	float y;
	float speed = 5;
	float power = 20;
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		Vector3 targetPos = new Vector3 (x, 0, y);
		targetPos = transform.TransformDirection(targetPos);
		transform.position += targetPos * speed * Time.deltaTime;
	}

	void OnCollisionStay(Collision other){
		if (other.gameObject.CompareTag("floor")) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				transform.position += transform.up * power * Time.deltaTime;
			}
		}
	}
}
