using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	
	private PlayerTouchControl playerMove;

	public void OnPointerDown(PointerEventData data){
		if(gameObject.name == "Left"){
			playerMove.SetMoveLeft(true);
		} else {
			playerMove.SetMoveLeft(false);
		}
	}

	public void OnPointerUp(PointerEventData data){
		playerMove.StopMove();
	}

	void Start(){
		playerMove = GameObject.Find("Player").GetComponent<PlayerTouchControl>();
	}
}
