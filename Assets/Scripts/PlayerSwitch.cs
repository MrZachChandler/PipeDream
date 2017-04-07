using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {

	public GameObject Bounce;
	public GameObject BounceP;

	public GameObject Ski;

	// Use this for initialization
	void Start () {

	}
	private bool next;

	public void OnCollisionStay() {
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("water")) {
			if (Ski.activeSelf == false) {
				Ski.gameObject.transform.position = BounceP.gameObject.transform.position;
				Ski.gameObject.transform.rotation = BounceP.gameObject.transform.rotation;
				Bounce.SetActive (false);
				Debug.Log ("THERE");

				Ski.SetActive (true);

			}
			if (Bounce.activeSelf) {
				Bounce.SetActive (false);
			}
		}
		if (other.gameObject.CompareTag("ground")) {
			if (Bounce.activeSelf == false) {
				BounceP.gameObject.transform.position = Ski.gameObject.transform.position;
				Bounce.gameObject.transform.position = Ski.gameObject.transform.position;
				Debug.Log ("HERE");
				Ski.SetActive (false);
				Bounce.SetActive (true);
			}
			if (Ski.activeSelf) {
				Ski.SetActive (false);
			}

		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
