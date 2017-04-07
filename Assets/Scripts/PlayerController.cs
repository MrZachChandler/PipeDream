using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

	public GameObject player1;
	public GameObject player2;
	public GameObject gameObjectA;
	public Animation anim;


	public int health = 50;
	public int score = 0;
	public bool alive = true;


    private int count;

	public GameObject remains;

	public float RotateSpeed = 70f;

	private int jumpCount;

    //int destroyCounter = 0;

    public Text scoreText;
    public Text winText;
    public Slider healthBar;
    public float downSpeed;

    //float timeCounter = 0;
    public bool isFalling;


    void Start() {

        rb = GetComponent<Rigidbody>();
        count = 0;
        alive = true;
    }

  

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("pickup")) {
			jumpCount = 0;
            other.gameObject.SetActive(false);
			count = 35;
			score += 1;
        }
        

    }



	public float jumpforce = 250.0f;  

	public float Speed = 7.0f;
	private float RotationSpeed = 250.0f;


	public void OnCollisionStay() {
		jumpCount = 0;
	}
	public void OnCollisionExit() {
	}  


	void Update () {

		if (player1.activeSelf) {
			gameObjectA = player1;
			anim = player1.GetComponent<Animation> ();

		}
		if (player2.activeSelf) {
			gameObjectA = player2;
		}

		healthBar.value = health;

		scoreText.text = "Score: " + score;

		if (health <= 0)
		{
			// game over
			alive = false;
		}

		if (count == 35) {
			Speed = Speed + 7.0f;
		}
		if (count == 0) {
			Speed = 12.0f;
		}
		if (count > 0) {
			count--;
		}

		if (player2.activeSelf) {


			if (Input.GetKeyDown ("space") && jumpCount < 2) {
				rb.AddForce (Vector3.up * jumpforce);
				jumpCount++;
			}
		}
	


			if (Input.GetButton ("up")) {
				transform.Translate (Vector3.forward * Time.deltaTime * Speed, Space.Self);
				//transform.Rotate (Vector3.right, Time.deltaTime * RotateSpeed, Space.Self);

				if (player1.activeSelf) {
				
				}
			}

			if (Input.GetButton ("down")) {
				transform.Translate (Vector3.forward * Time.deltaTime * -Speed, Space.Self);
				//transform.Rotate (Vector3.down, Time.deltaTime * -RotateSpeed, Space.Self);

			}

			if (Input.GetButton ("left")) {
				transform.Rotate (Vector3.up * Time.deltaTime * -RotationSpeed, Space.Self);	
				//transform.Rotate (Vector3.forward * -1, Time.deltaTime * -RotateSpeed, Space.Self);
			}

			if (Input.GetButton ("right")) {
				transform.Rotate (Vector3.up * Time.deltaTime * RotationSpeed, Space.Self);
				//transform.Rotate (Vector3.forward, Time.deltaTime * RotateSpeed, Space.Self);

			}

		if (player1.activeSelf) {
			
		}

	}
		

}
