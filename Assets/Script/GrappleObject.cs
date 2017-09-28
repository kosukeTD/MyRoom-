using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleObject : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	void OnMouseDown (){
		// マウスカーソルは、スクリーン座標なので、
		// 対象のオブジェクトもスクリーン座標に変換してから計算する。

		// このオブジェクトの位置(transform.position)をスクリーン座標に変換。
		screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		// ワールド座標上の、マウスカーソルと、対象の位置の差分。
		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}

	void OnMouseDrag (){
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + this.offset;
		//currentPosition.y = 0;
		transform.position = currentPosition;
	}







	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
