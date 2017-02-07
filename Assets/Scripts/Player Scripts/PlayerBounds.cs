using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

	private float minX, maxX, pWidthH;

	void Start () {
		SetMinAndMax();
	}

	void Update(){
		pWidthH = GetComponent<SpriteRenderer>().bounds.size.x/2f;
		if(transform.position.x < minX+pWidthH){
			Vector3 temp = transform.position;
			temp.x = minX+pWidthH;
			transform.position = temp;
		}

		if(transform.position.x > maxX-pWidthH){
			Vector3 temp = transform.position;
			temp.x = maxX-pWidthH;
			transform.position = temp;
		}

	}

	
	void SetMinAndMax(){
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		minX = -bounds.x;
		maxX = bounds.x;
	}
}
