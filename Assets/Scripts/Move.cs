using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float jumpforce = 250.0f;  
	private bool isgrounded = true; 

	public float Speed = 7.0f;
	private float RotationSpeed = 100.0f;
	private int count;


	public void OncollisionStay() {
		isgrounded = true;
	}
	public void OnCollisionExit() {
		isgrounded = false;
	}  

	public Rigidbody rb;
		
	void Start(){
		rb = GetComponent<Rigidbody>();
	}


	void Update () {

		if (count == 35) {
			Speed = Speed + 2.0f;
		}
		if (count == 0) {
			Speed = 5.0f;
		}
		if (count > 0) {
			count--;
		}


		if(Input.GetKeyDown("space") && isgrounded) {
			rb.AddForce(Vector3.up*jumpforce);
		}

		if(Input.GetButton("up")){
			transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.Self);
		}

		if(Input.GetButton("down")){
			transform.Translate(Vector3.forward * Time.deltaTime * -Speed, Space.Self);
		}

		if(Input.GetButton("left")){
			transform.Rotate(Vector3.up * Time.deltaTime * -RotationSpeed, Space.Self);
		}

		if(Input.GetButton("right")){
			transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed, Space.Self);
		}

	}
}
