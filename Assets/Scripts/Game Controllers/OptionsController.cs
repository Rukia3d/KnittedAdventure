using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour {

	[SerializeField]
	private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start () {
		SetDifficulty();
	}
		
	public void GoBackToMain(){
		Application.LoadLevel("MainMenu");
	}

	public void SetDifficulty(){
		resetDifficulties();
		int diff = GamePreferences.GetDifficultyState();
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
}
