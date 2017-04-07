using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockadeController : MonoBehaviour {

    private Rigidbody rb;
	private BoxCollider bc;
    bool didfall;

    private int count;

	public GameObject remains;
	public GameObject goodFlow;


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


    }

  

    void OnTriggerEnter(Collider other) {
		Debug.Log ("hit");
       
		if (other.gameObject.CompareTag("Player")){
			Debug.Log ("Player");
			//bc.enabled = false;
			Instantiate(goodFlow, transform.position, transform.rotation);
			Destroy(gameObject);

		}


    }
		



	void Update () {





	}
		

}
