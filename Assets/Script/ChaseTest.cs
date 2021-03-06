﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTest: MonoBehaviour {


	public Transform target1;//追いかける対象-オブジェクトをインスペクタから登録できるように
	public Transform target2;
	public Transform target3;

	public float speed = 0.1f;//移動スピード
	private Vector3 vec;



		void Start () {
			//target = GameObject.Find("対象").transform; インスペクタから登録するのでいらない

		}

		void Update () {
			//targetの方に少しずつ向きが変わる
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target1.position - transform.position), 0.3f);

			//targetに向かって進む
			//transform.position += transform.forward * speed;
		}

	void OnTriggerEnter(Collider checkPoint){
		if (checkPoint.gameObject.tag == "TagCP1") {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target1.position - transform.position), 0.3f);
			Debug.Log("TagCP1"+"を見る");
		}if (checkPoint.gameObject.tag == "TagCP2") {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target2.position - transform.position), 0.3f);
			Debug.Log("TagCP2"+"を見る");
		}if (checkPoint.gameObject.tag == "TagCP3") {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target3.position - transform.position), 0.3f);
			Debug.Log("TagCP3"+"を見る");
		}

	}
}