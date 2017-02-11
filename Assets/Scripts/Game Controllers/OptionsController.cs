using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	[SerializeField]
	private GameObject easySign, mediumSign, hardSign;

	[SerializeField]
	private Button musicBtn;

	[SerializeField]
	private Sprite[] musicIcon;

	// Use this for initialization
	void Start () {
		SetDifficulty();
		MusicButton();
	}
		
	public void GoBackToMain(){
		Application.LoadLevel("MainMenu");
	}

	public void SetDifficulty(){
		resetDifficulties();
		int diff = GamePreferences.GetDifficultyState();
		GamePreferences.SetHighScoreFor(diff);
		if(diff == 2){
			mediumSign.SetActive(true);
		} else if (diff == 3){
			hardSign.SetActive(true);
		} else {
			easySign.SetActive(true);
		}
	}

	public void EasyDifficulty(){
		GamePreferences.setDifficultyState(1);
		SetDifficulty();
	}

	public void MediumDifficulty(){
		GamePreferences.setDifficultyState(2);
		SetDifficulty();
	}

	public void HardDifficulty(){
		GamePreferences.setDifficultyState(3);
		SetDifficulty();
	}


	public void resetDifficulties(){
		easySign.SetActive(false);
		mediumSign.SetActive(false);
		hardSign.SetActive(false);
	}

	void CheckToPlayMusic(){
		if(GamePreferences.GetMusicState()==1){
			MusicController.instance.PlayMusic(true);
			musicBtn.image.sprite = musicIcon[0];
		} else {
			MusicController.instance.PlayMusic(false);
			musicBtn.image.sprite = musicIcon[1];
		}
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
