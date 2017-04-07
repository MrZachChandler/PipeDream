using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public GameObject player;
	public GameObject player1;
	public GameObject player2;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		if (player1.activeSelf) {
			player = player1;
		} else {
			player = player2;
		}
		offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player1.activeSelf) {
			player = player1;
		}
		if (player2.activeSelf) {
			player = player2;
		}
		transform.position = player.transform.position + offset;
	}
}
