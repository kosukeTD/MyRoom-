using UnityEngine;
using System.Collections;

namespace Kakera
{
    public class PickerController : MonoBehaviour
    {
        [SerializeField]
        private Unimgpicker imagePicker;

        [SerializeField]
        private MeshRenderer imageRenderer;

		//追記
		public static string imagePickingObjectName;


        void Awake()
        {
            imagePicker.Completed += (string path) =>
            {				
                //StartCoroutine(LoadImage(path, imageRenderer));
				//下記変更内容
				if(imagePickingObjectName == gameObject.name){
					StartCoroutine(LoadImage(path, imageRenderer));
				}
            };
        }

        public void OnPressShowPicker()
        {
			//下記追記
			imagePickingObjectName = gameObject.name;
			Debug.Log(gameObject.name);

            imagePicker.Show("Select Image", "unimgpicker", 1024);
        }

        private IEnumerator LoadImage(string path, MeshRenderer output)
        {
			//下記追記
			Debug.Log("aa:"+gameObject.name);

            var url = "file://" + path;
            var www = new WWW(url);
            yield return www;

			//下記追記
			//Debug.Log("aaaaaaaaaaaaaaaaaa");


            var texture = www.texture;
            if (texture == null)
            {
                Debug.LogError("Failed to load texture url:" + url);
            }

            output.material.mainTexture = texture;
        }
    }
}