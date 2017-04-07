using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	/*
	public int startingHealth = 100;
	public int curHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip dealthClip;
	public float flashSpeed= 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);


	Animator anim;
	AudioSource playerAudio;
	Bounce bounce;

	bool isDead;
	bool damaged;


	// Use this for initialization
	void Start () {
		//bounce = GetComponent<Bounce>;
		curHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = flashColor.Lerp (damageImage.color, flashColor.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	public void TakeDamage(int amount){
		damaged = true;
		curHealth -= amount;
		healthSlider.value = curHealth;

		if (curHealth <= 0 && !isDead) {
			Death ();
		}

	}
	void Death(){
		isDead = true;
	}
*/
}
