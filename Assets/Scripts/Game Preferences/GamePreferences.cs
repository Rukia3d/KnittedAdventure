using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences {
	public static string Difficulty = "Difficulty";

	public static int HighScoreFor = 1;

	public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	public static string HardDifficultyHighScore = "HardDifficultyHighScore";

	public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";

	//HighScoreFor
	public static void SetHighScoreFor(int state){
		GamePreferences.HighScoreFor = state;
	}

	public static int GetHighScoreFor(){
		return GamePreferences.HighScoreFor;
	}
	//Music
	public static void SetMusicState(int state){
		PlayerPrefs.SetInt(GamePreferences.IsMusicOn, state);
	}

	public static int GetMusicState(){
		return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
	}

	//Difficulty 1- Easy, 2- medium 3- hard
	public static void setDifficultyState(int state){
		Debug.Log("Call to setDifficultyState with Difficulty: "+state);
		PlayerPrefs.SetInt(GamePreferences.Difficulty, state);
	}

	public static int GetDifficultyState(){
		return PlayerPrefs.GetInt(GamePreferences.Difficulty);
	}
		
	//HighScore - easy
	public static void setEasyDifficultyHighScore(int state){
		PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, state);
	}

	public static int GetEasyDifficultyHighScore(){
		return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
	}

	//HighScore - medium
	public static void setMediumDifficultyHighScore(int state){
		PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, state);
	}

	public static int GetMediumDifficultyHighScore(){
		return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
	}

	//HighScore - hard
	public static void setHardDifficultyHighScore(int state){
		PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, state);
	}

	public static int GetHardDifficultyHighScore(){
		return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
	}

	//CoinScore - easy
	public static void setEasyDifficultyCoinScore(int state){
		PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, state);
	}

	public static int GetEasyDifficultyCoinScore(){
		return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
	}

	//CoinScore - medium
	public static void setMediumDifficultyCoinScore(int state){
		PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, state);
	}

	public static int GetMediumDifficultyCoinScore(){
		return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
	}

	//CoinScore - hard
	public static void setHardDifficultyCoinScore(int state){
		PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, state);
	}

	public static int GetHardDifficultyCoinScore(){
		return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
	}


}
  