using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int Score = 0;
	public int TargetScore = 400;
	public Text TxtScore = null;
	public Text TxtTime = null;
	public int timerPerLevel = 30;
	public GameObject YouWon = null;
	public GameObject GameOver = null;

	private float clockSpeed = 1f;

	void Awake() {
		TxtScore.text = "Score: " + Score + " / " + TargetScore;
		InvokeRepeating ("DeductTimer", 0f, clockSpeed);
	}

	private void DeductTimer(){
		timerPerLevel--;
		TxtTime.text = "Time : " + timerPerLevel;

		if (timerPerLevel == 0) {
			CheckForGameOver ();
		}
	}

	public void AddPoints(int points){
		Score += points;
		TxtScore.text = "Score: " + Score + " / " + TargetScore;

		if (Score >= TargetScore) {
			Time.timeScale = 0f;
			YouWon.SetActive (true);
		}
	}

	private void CheckForGameOver(){
		Time.timeScale = 0f;

		if (Score >= TargetScore) {
			YouWon.SetActive (true);
		} else if (Score < TargetScore && GameOver != null) {
			GameOver.SetActive (true);
		}
	}
}
