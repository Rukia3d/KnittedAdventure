using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	
	private PlayerTouchControl playerMove;

	public void OnPointerDown(PointerEventData data){
		/*Debug.Log("OnPointerDown start moving");
		if(SwipeManager.IsSwipingLeft()){
			playerMove.SetMoveLeft(true);
		} else if(SwipeManager.IsSwipingRight()){
			playerMove.SetMoveLeft(false);
		}*/

	}

	public void OnPointerUp(PointerEventData data){
		/*Debug.Log("Should stop moving");
		playerMove.StopMove();*/
	}
		

	void Start(){
		playerMove = GameObject.Find("Player").GetComponent<PlayerTouchControl>();

	}

	void Update(){
		if(SwipeManager.IsSwipingLeft()){
			playerMove.SetMoveLeft(true);
		} else if(SwipeManager.IsSwipingRight()){
			playerMove.SetMoveLeft(false);
		} else {
			playerMove.StopMove();
		}

	}
}
