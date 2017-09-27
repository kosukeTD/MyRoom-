using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_destroy : MonoBehaviour {

	//float speed = 0;

	public Transform point_1;
	public Transform point_2;
	public Transform point_3;
	public Transform point_4;


	float m_progress = 0f;      //  進捗 [0, 1)
	int m_ix = 0;               //  現データインデックス
	Vector3[] m_data = {new Vector3(-4f, 1f, -4f),
		new Vector3( 6f, 1f, -4f),
		new Vector3( 6f, 1f,  6f),
		new Vector3(-4f, 1f,  6f),
		new Vector3(-4f, 1f, -4f)};

	/*
	void OnTtiggerEnter(Collider other){
		//checkPoint.gameObject.tag == "tag_Start";
		Debug.Log ("Start!Point_1を見る");
		Destroy (other.gameObject);
	}
*/

	/*
	void OnTtiggerEnter(Collider checkPoint){
		if (checkPoint.gameObject.tag == "tag_Start") {
			Debug.Log ("Start!Point_1を見る");
			transform.LookAt (point_1);
		}if (checkPoint.gameObject.tag == "tag_A") {
			Debug.Log ("Point_2を見る");
			transform.LookAt (point_2);
		}if (checkPoint.gameObject.tag == "tag_B") {
			Debug.Log ("Point_3を見る");
			transform.LookAt (point_3);
		}if (checkPoint.gameObject.tag == "tag_C") {
			Debug.Log ("Point_4を見る");
			transform.LookAt (point_4);
		}
		*/

		/*
		void OnTriggerEnter(Collider other){
			Debug.Log ("Start!Point_1を見る");
		Destroy (other.gameObject);
}
		*/


	void Start () {

	}
	

	void Update () {
	/*	this.speed = 0.1f;
		transform.Translate (this.speed, 0f, 0f);*/

		m_progress += 0.2f * Time.deltaTime; //スピード
		if( m_progress >= 1.0f ) {
			m_progress = 0f;
			if( ++m_ix >= m_data.Length - 1)
				m_ix = 0;
		}
		transform.position = Vector3.Lerp(m_data[m_ix], m_data[m_ix+1], m_progress);

		
	}


/*
 void OnTtiggerEnter(Collider checkPoint){
		if (checkPoint.gameObject.tag == "tag_Start") {
			Debug.Log ("Start!Point_1を見る");
			transform.LookAt (point_1);
		}if (checkPoint.gameObject.tag == "tag_A") {
			Debug.Log ("Point_2を見る");
			transform.LookAt (point_2);
		}if (checkPoint.gameObject.tag == "tag_B") {
			Debug.Log ("Point_3を見る");
			transform.LookAt (point_3);
		}if (checkPoint.gameObject.tag == "tag_C") {
			Debug.Log ("Point_4を見る");
			transform.LookAt (point_4);
		}
		*/


	/*
	float m_progress = 0f;      //  進捗 [0, 1)
	int m_ix = 0;               //  現データインデックス
	Vector3[] m_data = {new Vector3(-4f, 1f, -4f),
		new Vector3( 4f, 1f, -4f),
		new Vector3( 4f, 1f,  4f),
		new Vector3(-4f, 1f,  4f),
		new Vector3(-4f, 1f, -4f)};

	void Start () {

		transform.position = m_data[m_ix];


	}

	void Update () {

		m_progress += 0.2f * Time.deltaTime; //スピード
		if( m_progress >= 1.0f ) {
			m_progress = 0f;
			if( ++m_ix >= m_data.Length - 1)
				m_ix = 0;
		}
		transform.position = Vector3.Lerp(m_data[m_ix], m_data[m_ix+1], m_progress);

	}
	*/



}



