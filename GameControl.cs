using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

/*
	public static GameControl instance = null;

	[SerializeField]
 	GameObject restartButton;

	[SerializeField]
	Text highScoreText;

	[SerializeField]
	Text yourScoreText;

	[SerializeField]
	GameObject[] obstacles;

	int highScore = 0, yourScore = 0;

	public static bool gameStopped;

	float nextScoreIncrease = 0f;
*/
	// Use this for initialization
	void Start () {
		
		if (instance == null) 
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		restartButton.SetActive (false);
		yourScore = 0;
		gameStopped = false;
		Time.timeScale = 1;
		highScore = PlayerPrefs.GetInt ("highScore");
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStopped)
			IncreaseYourScore ();

		highScoreText.text = "High Score: " + highScore;
		yourScoreText.text = "Your Score: " + yourScore;

	}

	public void DinoHit()
	{
		if (yourScore > highScore)
			PlayerPrefs.SetInt("highScore", yourScore);

		//	DinoControl.instance.death();
		Time.timeScale = 0;

		gameStopped = true;
		//	DinoControl.instance.freeze_DinoControl();
		//	MoveLeftCycle.instance.freeze_MoveLeftCycle();
		restartButton.SetActive (true);



	}

	void IncreaseYourScore()
	{
		if (Time.unscaledTime > nextScoreIncrease) {
			yourScore += 1;
			nextScoreIncrease = Time.unscaledTime + 1;
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene ("Scene01");
	}

}
