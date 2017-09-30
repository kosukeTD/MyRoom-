using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTest2: MonoBehaviour {


	public Transform target1;//追いかける対象-オブジェクトをインスペクタから登録できるように
	public Transform target2;
	public Transform target3;


	//下記だと全部に設定しないといけない
	//private bool "TagCP1" = false;

	//public float speed = 0.1f;//移動スピード

	//タグを保存
	private string touchingObjectTag;
	public float lookSpeed;//次の視点へのカメラのスピード


		void Start () {
			//target = GameObject.Find("対象").transform; インスペクタから登録するのでいらない

		}

		void Update () {
		//targetの方に少しずつ向きが変わる
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target1.position - transform.position), 0.3f);

		if (touchingObjectTag == "TagCP1") {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target1.position - transform.position), lookSpeed);
			Debug.Log("TagCP1"+"を見る");
		}if (touchingObjectTag == "TagCP2") {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target2.position - transform.position), lookSpeed);
			Debug.Log("TagCP2"+"を見る");
		}if (touchingObjectTag == "TagCP3") {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target3.position - transform.position), lookSpeed);
			Debug.Log("TagCP3"+"を見る");
		}


			//targetに向かって進む
			//transform.position += transform.forward * speed;
		}

	void OnTriggerEnter(Collider checkPoint){
		//オブジェクトに当たるとタグを保存
		if (checkPoint.gameObject.tag == "TagCP1") {
			touchingObjectTag = checkPoint.gameObject.tag;
		}if (checkPoint.gameObject.tag == "TagCP2") {
			touchingObjectTag = checkPoint.gameObject.tag;
		}if (checkPoint.gameObject.tag == "TagCP3") {
			touchingObjectTag = checkPoint.gameObject.tag;
		}
			
	}
}


