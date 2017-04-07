using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager1 : MonoBehaviour {

	GameObject[] pauseObjects;
	GameObject[] gameOverObjects;
	PlayerController bounce;
	public GameObject thePlayer;
	public Text gameOverScoreText;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;

		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		gameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");

		hidePaused();
		hideGameOver();
		bounce = thePlayer.GetComponent<PlayerController>();

		if (SceneManager.GetActiveScene().name == "level1")
		{
			Debug.Log("In the main scene");
			//bounce = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Bounce>();
			//bounce = thePlayer.GetComponent<PlayerController>();
			//Debug.Log("The player is alive: " + thePlayer.GetComponent<PlayerController>().alive);
		}

	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("The player is alive: " + thePlayer.GetComponent<PlayerController>().alive);

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1 && bounce.alive == true)
			{
				Time.timeScale = 0;
				showPaused();
				Debug.Log ("Show pause menu");
				Debug.Log ("GUI Enabled " + GUI.enabled);
			}
			else if (Time.timeScale == 0 && bounce.alive == true)
			{
				Time.timeScale = 1;
				hidePaused();
				Debug.Log ("Hide pause menu");
			}
		}

		// shows Game Over gameObjects if player is dead and timescale = 0

		if (bounce.alive == false)
		{
			Debug.Log("Player died.");
			gameOverScoreText.text = "Score: " + bounce.score;
			showGameOver();
		}
	}

	// Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene("level5", LoadSceneMode.Single);
	}

	//controls the pausing of the scene
	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
			Debug.Log ("Pressed the resume button");
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
			Debug.Log ("Game Object- " + g.name + " set to active.");
			Debug.Log ("TimeScale- " + Time.timeScale);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//shows objects with ShowOnGameOver tag
	public void showGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnGameOver tag
	public void hideGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level)
	{
		SceneManager.LoadScene(level);
	}

}
