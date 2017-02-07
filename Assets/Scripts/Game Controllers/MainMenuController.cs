using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button musicBtn;

	[SerializeField]
	private Sprite[] musicIcon;

	void Start () {
		CheckToPlayMusic();
	}

	void CheckToPlayMusic(){
		if(GamePreferences.GetMusicState()==1){
			MusicController.instance.PlayMusic(true);
			musicBtn.image.sprite = musicIcon[1];
		} else {
			MusicController.instance.PlayMusic(false);
			musicBtn.image.sprite = musicIcon[0];
		}
	}
	
	public void StartGame(){
		GameManager.instance.gameFromMain = true;
		//Application.LoadLevel("Gameplay");
		SceneFader.instance.LoadLevel("Gameplay");
	}

	public void HighscoreMenu(){
		Application.LoadLevel("HighScore");
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
