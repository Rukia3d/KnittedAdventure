using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameFromMain, gameRestart;

	[HideInInspector]
	public int score, coins, lifes;

	void Awake () {
		MakeSingleton();
	}

	void Start(){
		InitializeGP();
	}

	void InitializeGP(){
		if(!PlayerPrefs.HasKey("GameInit")){
			Debug.Log("Callo to InitializeGP without the Key");
			GamePreferences.setDifficultyState(1);

			GamePreferences.SetMusicState(0);

			GamePreferences.setEasyDifficultyHighScore(0);
			GamePreferences.setMediumDifficultyHighScore(0);
			GamePreferences.setHardDifficultyHighScore(0);

			GamePreferences.setEasyDifficultyCoinScore(0);
			GamePreferences.setMediumDifficultyCoinScore(0);
			GamePreferences.setHardDifficultyCoinScore(0);

			PlayerPrefs.SetInt("GameInit", 1);
		} else {
			GamePreferences.SetHighScoreFor(GamePreferences.GetDifficultyState());
		}

	}

	void OnLevelWasLoaded(){
		if(Application.loadedLevelName == "Gameplay"){
			if(gameRestart){
				GameplayController.instance.SetScore(score);
				GameplayController.instance.SetCoinScore(coins);
				GameplayController.instance.SetLifeScore(lifes);

				PlayerScore.scoreCount = score;
				PlayerScore.lifeScore = lifes;
				PlayerScore.coinScore = coins;
			} else if(gameFromMain){
				GameplayController.instance.SetScore(0);
				GameplayController.instance.SetCoinScore(0);
				GameplayController.instance.SetLifeScore(2);

				PlayerScore.scoreCount = 0;
				PlayerScore.lifeScore = 2;
				PlayerScore.coinScore = 0;
			}
		}
	}

	void MakeSingleton() {
		if(instance!=null){
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	public void CheckScores(int oldScore, int newScore){
		Debug.Log("Cll to CheckScores on gameManager, new is: "+newScore+" old is: "+oldScore);
		if(newScore > oldScore){
			if(GamePreferences.GetDifficultyState()==2){
				GamePreferences.setMediumDifficultyHighScore(newScore);
			}else if (GamePreferences.GetDifficultyState()==3) {
				GamePreferences.setHardDifficultyHighScore(newScore);
			}else {
				GamePreferences.setEasyDifficultyHighScore(newScore);
			}
		}
	}
	public void CheckCoins(int oldCoins, int newCoins ){
		if(newCoins > oldCoins){
			if(GamePreferences.GetDifficultyState()==2){
				GamePreferences.setMediumDifficultyCoinScore(newCoins);
			}else if (GamePreferences.GetDifficultyState()==3) {
				GamePreferences.setHardDifficultyCoinScore(newCoins);
			}else {
				GamePreferences.setEasyDifficultyCoinScore(newCoins);
			}
		}
	}
	public void CheckGameStatus(int score, int coins, int lifes){
		Debug.Log("Call to CheckGameStatus with score: "+score+" coins: "+coins+" and lifes: "+lifes);
		if(lifes <0){
			int highScore;
			int coinScore; 

			if(GamePreferences.GetDifficultyState()==2){
				highScore = GamePreferences.GetMediumDifficultyHighScore();
				coinScore = GamePreferences.GetMediumDifficultyCoinScore();

			} else if (GamePreferences.GetDifficultyState()==3){
				highScore = GamePreferences.GetHardDifficultyHighScore();
				coinScore = GamePreferences.GetHardDifficultyCoinScore();

			} else {
				highScore = GamePreferences.GetEasyDifficultyHighScore();
				coinScore = GamePreferences.GetEasyDifficultyCoinScore();

			}
			CheckScores(highScore, score);
			CheckCoins(coinScore, coins);


			gameFromMain = false;
			gameRestart = false;
			GameplayController.instance.GameOverShowPanel(score, coins);

		} else {
			this.score = score;
			this.coins = coins;
			this.lifes = lifes;

			gameFromMain = false;
			gameRestart = true;

			GameplayController.instance.PlayerDiedRestartTheGame();
		}
	}
}
