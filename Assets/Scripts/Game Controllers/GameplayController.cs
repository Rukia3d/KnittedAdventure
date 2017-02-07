﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	//Change life text to life images later
	[SerializeField]
	private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private GameObject readyButton;

	void Awake(){
		MakeInstance();
	}

	void Start(){
		Time.timeScale = 0f;
	}

	void MakeInstance(){
		if(instance == null){
			instance = this;
		}
	}

	public void GameOverShowPanel(int score, int coin){
		gameOverPanel.SetActive(true);
		gameOverScoreText.text = score.ToString();
		gameOverCoinText.text = coin.ToString();
		StartCoroutine(GameOverLoadMainMenu());
	}

	public void PlayerDiedRestartTheGame(){
		StartCoroutine(PlayerDiedRestart());
	}

	IEnumerator GameOverLoadMainMenu(){
		//Later switch for the main menu with all 3 games
		yield return new WaitForSeconds(3f);
		SceneFader.instance.LoadLevel("MainMenu");
	}

	IEnumerator PlayerDiedRestart(){
		yield return new WaitForSeconds(1f);
		SceneFader.instance.LoadLevel("Gameplay");
	}

	public void SetScore(int score){
		scoreText.text = "x"+score;
	}

	public void SetCoinScore( int score){
		coinText.text = "x"+score;
	}

	public void SetLifeScore(int score){
		lifeText.text = "x"+score;
	}


	public void PauseGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}

	public void QuitGame(){
		Time.timeScale = 1f;
		SceneFader.instance.LoadLevel("MainMenu");
	}

	public void StartTheGame(){
		Time.timeScale = 1f;
		readyButton.SetActive(false);
	}


}
