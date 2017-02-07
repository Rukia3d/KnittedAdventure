using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private float speed = 1f;
	private float acceleration = 0.1f;
	private float maxSpeed = 3.2f;

	private float easyMSpeed = 3.2f;
	private float mediumMSpeed = 4.0f;
	private float hardMSpeed = 4.5f;

	[HideInInspector]
	public bool moveCamera;

	// Use this for initialization
	void Start () {
		if(GamePreferences.GetDifficultyState()==2){
			maxSpeed = easyMSpeed; 
		}else if (GamePreferences.GetDifficultyState()==3) {
			maxSpeed = mediumMSpeed;
		}else {
			maxSpeed = hardMSpeed;
		}
		moveCamera = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if(moveCamera){
			MoveCamera();
		}
	}

	void MoveCamera(){
		Vector3 temp = transform.position;
		float oldY = temp.y;
		float newY = temp.y - (speed * Time.deltaTime);

		temp.y = Mathf.Clamp(temp.y, oldY, newY);

		transform.position = temp;

		speed += acceleration * Time.deltaTime;

		if (speed > maxSpeed){
			speed = maxSpeed;
		}
		
	}

}
