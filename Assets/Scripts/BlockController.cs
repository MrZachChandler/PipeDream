using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockController : MonoBehaviour {

    private Rigidbody rb;
	private BoxCollider bc;
    bool didfall;

    private int count;

	public GameObject remains;
	public GameObject parentcube;
	public GameObject Goodflow;
	public GameObject BadFlow;


	public float RotateSpeed = 70f;

	private int jumpCount;

    int destroyCounter = 0;

    public Text countText;
    public Text winText;
    public Slider healthBar;
    public float downSpeed;

    float timeCounter = 0;
    public int health = 50;
    public bool isFalling;

    public bool alive = true;

    void Start() {
		bc = GetComponent<BoxCollider> ();
        rb = GetComponent<Rigidbody>();
        count = 0;
        alive = true;
		if (gameObject.CompareTag ("remains")) {
			Destroy (gameObject, 1f);
		}
    }

  

    void OnTriggerEnter(Collider other) {
        

		if (other.gameObject.CompareTag("Player")){
			//bc.enabled = false;
			if(gameObject.CompareTag("blockade")){
				StartCoroutine ("DoSomething2");
				GameObject outTile = BadFlow;
				Instantiate(Goodflow, outTile.transform.position, outTile.transform.rotation);
				Destroy(BadFlow);
			}
			if (gameObject.CompareTag ("Breakopen")) {
				StartCoroutine ("DoSomething2");

			}
			 else {
				StartCoroutine ("DoSomething");
			}

		}
		if (other.gameObject.CompareTag("remains")){
			Debug.Log("remains");
			//bc.enabled = false;


		}

    }

	IEnumerator DoSomething()
	{
		yield return new WaitForSeconds(2f);
		GameObject gb = (GameObject) Instantiate(remains, transform.position, transform.rotation);
		yield return new WaitForSeconds(2f);
		Destroy (gameObject);
		Destroy (gb, 2f);
		print("Ok");
	}
	IEnumerator DoSomething2()
	{
		GameObject gb = (GameObject) Instantiate(parentcube, transform.position, transform.rotation);
		Destroy(gameObject);
		yield return new WaitForSeconds(2f);
		Destroy (gameObject);
		Destroy (gb, 2f);
		print("Ok");
	}
	/*
	void platformUpdate(Collider go , bool check , float timeCounter)
	{
		timeCounter += Time.deltaTime;
		if (check) {
			downSpeed += Time.deltaTime / 10;
			go.gameObject.transform.position = new Vector3 (go.transform.position.x,
				go.gameObject.transform.position.y - downSpeed, 
				go.gameObject.transform.position.z);

		}
		destroyCounter++;
	
		platformUpdate (go , check , timeCounter);

	}*/

	public float jumpforce = 250.0f;  
	private bool isgrounded = true; 

	public float Speed = 7.0f;
	private float RotationSpeed = 250.0f;


	public void OnCollisionStay() {
		isgrounded = true;
		jumpCount = 0;
	}
	public void OnCollisionExit() {
		isgrounded = false;
	}  



	void Update () {

		//healthBar.value = health;




	}
		

}
