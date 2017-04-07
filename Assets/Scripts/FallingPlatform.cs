using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	float timeCounter = 0;
	bool isFalling = false;
	float downSpeed = 0;

	void OnTriggerEnter(Collider collider){
	
		if (collider.gameObject.name == "Player") {
			isFalling = true;
			Debug.Log ("I should fall", gameObject);
			Destroy (gameObject, 10);
		}

	}
	 
	void Update()
	{
		timeCounter += Time.deltaTime;
		if (isFalling) {
			downSpeed += Time.deltaTime / 10;
			transform.position = new Vector3 (transform.position.x,
				transform.position.y - downSpeed, 
				transform.position.z);

		}
	}
	
}
