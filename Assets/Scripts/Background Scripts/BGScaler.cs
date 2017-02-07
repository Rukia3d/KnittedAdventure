using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	void Start () {

		SpriteRenderer spr = GetComponent<SpriteRenderer>();
		Vector3 tempScale = transform.localScale;
		float width = spr.sprite.bounds.size.x;

		float worldHeight = Camera.main.orthographicSize * 2.0f;
		float worldWidth = worldHeight / Screen.height * Screen.width;

		tempScale.x = worldWidth / width;
		transform.localScale = tempScale;
		
	}

}
