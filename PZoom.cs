using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PZoom : MonoBehaviour {

	public float pZoomSpeed = 0.5f;
	public float oZoomSpeed = 0.5f;
	public Camera cam;

	// public Button top;
	// public Button bottom;
	// public Button right;
	// public Button left;

	public Vector2 StartPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if(input.touchCount>=2){
		// 	Vector2 touch0,touch1;
		// 	float d;
		// 	touch0 = Input.getTouch(0).position;
		// 	touch1 = Input.getTouch(1).position;
		// 	d = Mathf.Abs(Vector2.Distance(touch0,touch1));
		// }
		// ----------------------
		// if (Input.touchCount==2 && 
		// (Input.GetTouch(0).phase == TouchPhase.Began || 
		// 	Input.GetTouch(1).phase == TouchPhase.Began)){
		// 		previousDistance = Vector2.Distance(Input.GetTouch(0).position,Input.GetTouch(1).position);
		
		// }else if (Input.touchCount==2 &&
		// (Input.GetTouch(0).phase == TouchPhase.Moved || 
		// 	Input.GetTouch(1).phase == TouchPhase.Moved)){
				
		// 		float distance;
		// 		Vector2 touch1 = Input.GetTouch(0).position;
		// 		Vector2 touch2 = Input.GetTouch(1).position;

		// 		distance = Vector2.Distance(touch1,touch2);

		// 		float pinchMount = (previousDistance - distance) * zoomSpeed * Time.deltaTime;
		// 		Camera.main.transform.Translate(0,0,pinchMount);

		// 		previousDistance = distance;
		// }

		if (Input.touchCount ==1) {
			Touch touch= Input.GetTouch(0);
			if (touch.phase == TouchPhase.Moved){
				Vector2 NewPosition = GetWorldPosition();
				Vector2 PositionDifference = NewPosition - StartPosition;
				cam.transform.Translate(-PositionDifference);
			}
			StartPosition = GetWorldPosition();

		} else if (Input.touchCount ==2){
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			if(cam.orthographic){
				cam.orthographicSize+= deltaMagnitudeDiff * oZoomSpeed;
				cam.orthographicSize = Mathf.Max(cam.orthographicSize, .1f);
			} else {
				cam.fieldOfView += deltaMagnitudeDiff * pZoomSpeed;
				cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, .1f,179.9f);
			}
		}
		
	}
	Vector2 GetWorldPosition() {
		return cam.ScreenToWorldPoint(Input.mousePosition);
	}
}
