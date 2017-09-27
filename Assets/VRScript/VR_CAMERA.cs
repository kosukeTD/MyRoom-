using UnityEngine;
using System.Collections;

public class VR_CAMERA : MonoBehaviour {
	//携帯のジャイロ機能を読み込むスクリプト
	
	public GameObject Head;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}

	// Update is called once per frame
	void Update () {

		if (Input.gyro.enabled)
		{
			Quaternion direction = Input.gyro.attitude;
			Head.transform.localRotation = Quaternion.Euler(90, 0, -90) * (new Quaternion(-direction.x,-direction.y, direction.z, direction.w));
		}
	}
}