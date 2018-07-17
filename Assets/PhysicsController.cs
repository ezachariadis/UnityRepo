using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {
	float x;
	float y;
	float speed = 500;
	float power = 20;
	Rigidbody objectRigidbody;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		objectRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		targetPos = new Vector3 (x, 0, y);
		targetPos = transform.TransformDirection(targetPos);
		Debug.Log(objectRigidbody.velocity);

	}

	void FixedUpdate(){
		objectRigidbody.AddForce(targetPos * speed * Time.fixedDeltaTime, ForceMode.Force);
	}

	void OnCollisionStay(Collision other){
		if (other.gameObject.CompareTag("floor")) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				objectRigidbody.AddForce(transform.up * power, ForceMode.Impulse);
			}
		}
	}
}
