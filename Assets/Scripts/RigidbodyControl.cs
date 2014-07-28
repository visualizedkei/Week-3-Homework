using UnityEngine;
using System.Collections;

public class RigidbodyControl : MonoBehaviour {
	// make variables public to edit in unity
	// number in inspector will override the number here
	float turnSpeed = 500f;
	float moveSpeed = 750f;
	
	// Update is called once per frame
	void Update() {
		// turn using horizontal Mouse movement... does NOT use physics system (torque)
		GetComponent<Transform>().Rotate(0f, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0f);
	}

	// all Physics rigibody calls should be made in FixedUpdate
	void FixedUpdate() {
		// physics force, movement forward and backward, using keyboard "Vertical" axis
		Vector3 moveVector = transform.forward * Input.GetAxis("Vertical") + 
			transform.right * Input.GetAxis("Horizontal");
		//GetComponent<Rigidbody>().AddForce(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
		// physics force, movement sideways, using keyboard Horizontal axis
		GetComponent<Rigidbody>().AddForce(moveVector * moveSpeed * Time.deltaTime);
	}
}