using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {


	void Start () {
		CheckToPlayMusic();
	}

	void CheckToPlayMusic(){
		if(GamePreferences.GetMusicState()==1){
			MusicController.instance.PlayMusic(true);
			//musicBtn.image.sprite = musicIcon[1];
		} else {
			MusicController.instance.PlayMusic(false);
			//musicBtn.image.sprite = musicIcon[0];
		}
	}
	
	public void StartGame(){
		GameManager.instance.gameFromMain = true;
		//Application.LoadLevel("Gameplay");
		SceneFader.instance.LoadLevel("Gameplay");
	}

	public void HighscoreMenu(){
		if(GamePreferences.GetDifficultyState()==1){
			GamePreferences.SetHighScoreFor(1);
			Application.LoadLevel("HighScoreEasy");
		}

		if(GamePreferences.GetDifficultyState()==2){
			GamePreferences.SetHighScoreFor(2);
			Application.LoadLevel("HighScoreMedium");
		}

		if(GamePreferences.GetDifficultyState()==3){
			GamePreferences.SetHighScoreFor(3);
			Application.LoadLevel("HighScoreHigh");
		}
	}

	public void OptionsMenu(){
		Application.LoadLevel("Options");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MusicButton(){
		if(GamePreferences.GetMusicState()== 0){
			GamePreferences.SetMusicState(1);
		} else {
			GamePreferences.SetMusicState(0);
		}
		CheckToPlayMusic();
	}


}
