using UnityEngine;
using System.Collections;

namespace Kakera
{
    public class PickerControllerAll2 : MonoBehaviour
	{
		[SerializeField]
		private Unimgpicker imagePicker;

		[SerializeField]
		private MeshRenderer imageRenderer;

		[SerializeField]
		private MeshRenderer imageRenderer2;

		[SerializeField]
		private MeshRenderer imageRenderer3;

		[SerializeField]
		private MeshRenderer imageRenderer4;

		[SerializeField]
		private MeshRenderer[] imageRenderers;

		//追記　3 共通のテクスチャにするために下記を削除
		//追記 1 
		//public static string imagePickingObjectName;

		//追記 2 Materialsの配列を指定するためのインデックス
		int index = 0;

		void Awake()
		{
			imagePicker.Completed += (string path) =>
			{			
				//下記を使うとpickerControllerに設定したマテリアルが全部変わってしまう	
				//StartCoroutine(LoadImage(path, imageRenderer));
				//下記変更内容
				if(PickerController.imagePickingObjectName == gameObject.name){
					for(int i=0;i< imageRenderers.Length;i++){						
						StartCoroutine(LoadImage(path, imageRenderers[i]));
					}

				}
				//if(PickerController.imagePickingObjectName == gameObject.name){
				//	StartCoroutine(LoadImage(path, imageRenderer2));
				//}
			};



		}

		public void OnPressShowPicker()
		{
			//下記追記 1
			PickerController.imagePickingObjectName = gameObject.name;
			Debug.Log(gameObject.name);

			//for分追記 2 これでimagePicker.Showは「画像を選んで貼る」まで行ってくれるので、マテリアルの数だけ実行すれば全てのマテリアルに画像が貼られる。
			for (int i = 0; i < imageRenderer.materials.Length; i++) {
				imagePicker.Show("Select Image", "unimgpicker", 1024);

			}

		}

		private IEnumerator LoadImage(string path, MeshRenderer output)
		{

			//下記追記 1
			//Debug.Log("aa:"+gameObject.name);

			var url = "file://" + path;
			var www = new WWW(url);
			yield return www;

			//下記追記 1
			//Debug.Log("aaaaaaaaaaaaaaaaaa");


			var texture = www.texture;
			if (texture == null)
			{
				Debug.LogError("Failed to load texture url:" + url);
			}

			//下記変更 2
			//output.material.mainTexture = texture;
			output.materials[index].mainTexture = texture;
			//下記2回目の設定値
			index++;
			//テクスチャの数が複数ある場合はエラーが出るので下記を追加
			if (imageRenderer.materials.Length <= index) {
				index = 0;
			}

			//for(int i = 0; i < imageRenderer.materials.Length; i++){
			//	index++;
			//};
			//index = 0;




		}
	}
}
