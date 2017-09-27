using System.Collections;
using UnityEngine;

public class FollowPlayer_Look : MonoBehaviour {

	public Transform target; //ターゲットへの参照
	private Vector3 offset; //相対座標
	public GameObject targetObj; //ターゲットを注視

	void Start()
	{
		//自分自身とtargetとの相対距離を求める
		offset = GetComponent<Transform> ().position - target.position;
	}

	void Update()
	{
		//自分自身の座標に、targetの座業に相対座標を足した値を設定する
		GetComponent<Transform> ().position = target.position + offset;
		//ターゲットを注視
		this.gameObject.transform.LookAt (targetObj.transform);

	}

}
