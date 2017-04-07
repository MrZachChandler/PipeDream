using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	public float lerpSpeed = 5;
	public float scaleSpeed = 3;
	public Transform child;
	public float scaleChange = 0.1f;
	public AnimationCurve ac;
	public Animation anim;
	float scalePerc;

	float currentScaleTime;
    float currentLerpTime;
    float percentage = 1;




    Vector3 startPos;
    Vector3 endPos;

	Vector3 startScale;
	Vector3 endScale;


    bool firstInput;
    public bool justJump;

    public bool alive;

    void Start()
    {
		anim = gameObject.transform.FindChild ("Player").GetComponent<Animation> ();
		child = gameObject.transform.FindChild ("Player");

        alive = true;

    }

	// Update is called once per frame
	void Update () {

	    if (Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right")) {
            
			currentScaleTime = 0;

        }
		if (Input.GetButton("up") || Input.GetButton("down") || Input.GetButton("left") || Input.GetButton("right")) {

			startScale = gameObject.transform.localScale;
			endScale = new Vector3 (transform.localScale.x + scaleChange, transform.localScale.y - scaleChange, transform.localScale.z);
			firstInput = true;

		}
		if (Input.GetButtonUp("up") || Input.GetButtonUp("down") || Input.GetButtonUp("left") || Input.GetButtonUp("right")) {

			if (percentage >= 1) {

				anim.Play ("Jump");
				currentLerpTime = 0;
				currentScaleTime = 0;
				percentage = 0;
				startPos = gameObject.transform.position;
				startScale = gameObject.transform.localScale;
				endScale = new Vector3 (1, 1, 1);

			}
		}
        
        startPos = gameObject.transform.position;

        if (Input.GetButtonUp("right") && gameObject.transform.position == endPos) {
            endPos = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonUp("left") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonUp("up") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
        }
        if (Input.GetButtonUp("down") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
        }

       


        if (firstInput) {
			
			currentLerpTime += Time.deltaTime * lerpSpeed;
            percentage = currentLerpTime;
			gameObject.transform.position = Vector3.Lerp(startPos, endPos, ac.Evaluate(percentage));

			currentScaleTime += Time.deltaTime * scaleSpeed;
			scalePerc = currentScaleTime;
			child.transform.localScale = Vector3.Lerp (startScale,endScale, ac.Evaluate(scalePerc));
        }
        
    }
}
