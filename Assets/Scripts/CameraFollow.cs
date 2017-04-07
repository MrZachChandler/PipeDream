using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    Vector3 shouldPos;

	// Update is called once per frame
	void Update () {
        shouldPos = Vector3.Lerp(gameObject.transform.position, player.transform.position, Time.deltaTime);
		gameObject.transform.position = new Vector3(shouldPos.x, 5, shouldPos.z);
	}
}
