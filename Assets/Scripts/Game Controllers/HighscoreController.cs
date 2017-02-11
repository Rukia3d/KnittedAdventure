using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText, coinText;

	private int diff;


	// Use this for initialization
	void Start () {
		Debug.Log("Call to Start in HighscoreController");
		diff = GamePreferences.GetHighScoreFor();
		SetScore(diff);
	}

	void SetScore(int diff){
		Debug.Log("Call to SetScore");
		int score, coins; 
		if(diff == 2){
			score = GamePreferences.GetMediumDifficultyHighScore();
			coins = GamePreferences.GetMediumDifficultyCoinScore();
		}
		else if (diff ==3){
			score = GamePreferences.GetHardDifficultyHighScore();
			coins = GamePreferences.GetHardDifficultyCoinScore();
		}
		else {
			score = GamePreferences.GetEasyDifficultyHighScore();
			coins = GamePreferences.GetEasyDifficultyCoinScore();
		}

		scoreText.text = score.ToString();
		coinText.text = coins.ToString();
	}

	/*
	void SetScoreBasedOnDifficulty(){
		Debug.Log("Call to SetScoreBasedOnDifficulty in HighscoreController");
		if(GamePreferences.GetDifficultyState()==1){
			SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
		}

		if(GamePreferences.GetDifficultyState()==2){
			SetScore(GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());
		}

		if(GamePreferences.GetDifficultyState()==3){
			SetScore(GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());
		}
	}*/

	
	public void GoBackToMain(){
		Application.LoadLevel("MainMenu");
	}

	public void SwitchHighscore(int diff){
		GamePreferences.SetHighScoreFor(diff);
		Debug.Log("Call to SwitchHighscore with diff "+diff);

		if(diff==1){
			Application.LoadLevel("HighScoreEasy");
			SetScore(diff);
		}else if(diff==2){
			Application.LoadLevel("HighScoreMedium");
			SetScore(diff);
		}else{
			Application.LoadLevel("HighScoreHigh");
			SetScore(diff);
		}
	}


}
