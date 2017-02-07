using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

	private float destDelay = 6f;

	void OnEnable(){
		Invoke("DestroyCollectable", destDelay);
	}

	void DestroyCollectable(){
		gameObject.SetActive(false);
	}


}
