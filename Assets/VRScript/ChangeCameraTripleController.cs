using UnityEngine;
using System.Collections;

public class ChangeCameraTripleController : MonoBehaviour {

	public Camera mainCamera;
	//下記subCameraをsubCamera1に変更
	public Camera subCamera1;
	//下記追記
	public Camera subCamera2;

	// 「bool」は「true」か「false」の二択の情報を扱うことができます（ポイント）
	private bool mainCameraON = true;
	//下記追記
	private bool subCamera1ON = false;
	private bool subCamera2ON = false;


	void Start () {
		mainCamera.enabled = true;
		//下記追記
		subCamera1.enabled = false;
		subCamera2.enabled = false;
	}

	void Update () {

		// （重要ポイント）「&&」は論理関係の「かつ」を意味する。
		// 「A && B」は「A かつ B」（条件AとBの両方が揃った時という意味）
		// 「==」は「左右が等しい」という意味

		// もしも「Cボタン」を押した時、「かつ」、「mainCameraON」のステータスが「true」の時（条件）
		if(Input.GetKeyDown(KeyCode.C) && mainCameraON == true){
			mainCamera.enabled = false;
			//下記1に変更
			subCamera1.enabled = true;
			//下記追記
			subCamera2.enabled = false;

			mainCameraON = false;
			//下記追記
			subCamera1ON = true;
			subCamera2ON = false;


			// もしも「Cボタン」を押した時、「かつ」、「mainCameraON」のステータスが「false」の時（条件）
			//下記変更
		//} else if(Input.GetKeyDown(KeyCode.C) && mainCameraON == false){
		}else if(Input.GetKeyDown(KeyCode.C)&& subCamera1ON == true){
			//変更
			mainCamera.enabled = false;
			//下記1に変更
			subCamera1.enabled = false;
			subCamera2.enabled = true;

			//変更
			mainCameraON = false;
			subCamera1ON = false;
			subCamera2ON = true;
		}else if (Input.GetKeyDown(KeyCode.C) && subCamera2ON == true) {
			mainCamera.enabled = true;
			subCamera1.enabled = false;
			subCamera2.enabled = false;

			mainCameraON = true;
			subCamera1ON = false;
			subCamera2ON = false;
		}
	}
}