using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {
	[SerializeField]
	private AudioClip coinClip, lifeClip;

	private CameraScript cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int scoreCount;
	public static int lifeScore;
	public static int coinScore;

	private int pointsForLife = 150;
	private int pointsForCoin = 100;

	[SerializeField]
	private GameObject catCollision;

	void Awake(){
		cameraScript = Camera.main.GetComponent<CameraScript>();
	}


	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
		countScore = true;
		catCollision.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		CountScore();
	}

	void CountScore(){
		if(countScore){
			if(transform.position.y < previousPosition.y){
				scoreCount++;
			}
			previousPosition = transform.position;
			GameplayController.instance.SetScore(scoreCount);
		}

	}

	void OnTriggerEnter2D(Collider2D target){
		
		if(target.tag=="Coin"){
			coinScore++;
			scoreCount+=pointsForCoin;

			GameplayController.instance.SetScore(scoreCount);
			GameplayController.instance.SetCoinScore(coinScore);

			AudioSource.PlayClipAtPoint(coinClip, transform.position);
			target.gameObject.SetActive(false);
		}

		if(target.tag=="Life"){
			lifeScore++;
			scoreCount+=pointsForLife;

			GameplayController.instance.SetScore(scoreCount);
			GameplayController.instance.SetLifeScore(lifeScore);

			AudioSource.PlayClipAtPoint(lifeClip, transform.position);
			target.gameObject.SetActive(false);
		}

		if(target.tag=="Bounds"){
			cameraScript.moveCamera = false;
			countScore = false;

			transform.position = new Vector3(500,500,0);
			lifeScore--;
			//no need for animation
			GameManager.instance.CheckGameStatus(scoreCount, coinScore, lifeScore);
		}

		if(target.tag=="Deadly"){
			Debug.Log("Trying at animation");
			cameraScript.moveCamera = false;
			countScore = false;

			catCollision.SetActive(true);
			Vector3 temp = transform.position;

			catCollision.transform.position = new Vector3(temp.x, temp.y-1,0);

			transform.position = new Vector3(500,500,0);
			lifeScore--;

			//Dog-Cat collision animation
			GameManager.instance.CheckGameStatus(scoreCount, coinScore, lifeScore);
		}

	}

}
