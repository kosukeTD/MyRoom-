using System.Collections;
using UnityEngine;

public class iTween_Line : MonoBehaviour {
	public int time=100;
	public string PathName="New Path 1";
	public GameObject targetObj;


	void Start () {
		iTween.MoveTo (this.gameObject, iTween.Hash (
			"path", iTweenPath.GetPath (PathName),
			"time", time,
			"easeType", iTween.EaseType.linear,
			"orienttopath", true));
	}

	void Update(){
		this.gameObject.transform.LookAt (targetObj.transform);
	}
}
