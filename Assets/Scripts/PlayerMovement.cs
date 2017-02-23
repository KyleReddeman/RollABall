using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float force;
	public float jumpForce;

	private Rigidbody rigid;
	private float horizontalInput;
	private float verticalInput;
	private bool jumping = false;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		jumping = Input.GetButtonDown("Jump");
		if(Input.GetButtonDown("Submit")) {
			rigid.velocity = Vector3.zero;
			transform.rotation = Quaternion.identity;
			transform.position = Vector3.zero + new Vector3(0f, 1f, 0f);

		}
	}

	void FixedUpdate() {
		
		rigid.AddForce(Vector3.right * horizontalInput * force);
		Ray ray = new Ray(transform.position, Vector3.down);
		bool canJump = Physics.Raycast(ray, .53f, 1 << LayerMask.NameToLayer("Ground"));
		if(canJump) {
			rigid.AddForce(Vector3.forward * verticalInput * force);
			if(jumping) {
				rigid.AddForce(Vector3.up * jumpForce);
			}
		}

	}
}
