using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * フレームレート測定モニタv2
 * 2016/9/9 Fantom
 */
public class FpsMonitor : MonoBehaviour {

	//測定用
	int tick = 0;
	float elapsed = 0;
	float fps = 0;

	//表示基準位置用
	public enum Alignment
	{
		LeftTop,	//画面左上
		RightTop,	//画面右上
		LeftBottom,	//画面左下
		RightBottom,//画面右下
	}
	
	public Alignment alignment = Alignment.LeftTop;

	//外観設定(デフォルト値)
	const float GUI_WIDTH = 75f;	//GUI矩形幅
	const float GUI_HEIGHT = 30f;	//GUI矩形高さ
	const float MARGIN_X = 10f;		//画面からの横マージン
	const float MARGIN_Y = 10f;		//画面からの縦マージン
	const float INNER_X = 8f;		//文字のGUI外枠からの横マージン
	const float INNER_Y = 5f;		//文字のGUI外枠からの縦マージン

	//オフセット位置(MARGIN_X, MARGIN_Y)ユーザー設定用
	public Vector2 offset = new Vector2(MARGIN_X, MARGIN_Y);
	public bool boxVisible = true;			//囲みボックスの可視フラグ
	public float boxWidth = GUI_WIDTH;		//囲みボックスの幅
	public float boxHeight = GUI_HEIGHT;	//囲みボックスの高さ
	public Vector2 padding = new Vector2(INNER_X, INNER_Y);

	float x, y;		//表示位置
	Rect outer;		//外枠(GUI矩形領域)
	Rect inner;		//内枠(文字領域)

	//画面サイズ変更チェック用
	int oldScrWidth;
	int oldScrHeight;


	// Use this for initialization
	void Start () {
		oldScrWidth = Screen.width;
		oldScrHeight = Screen.height;
		LocateGUI();
	}

	// Update is called once per frame
	void Update () {
		tick++;
		elapsed += Time.deltaTime;
		if (elapsed >= 1f) {
			fps = tick / elapsed;
			tick = 0;
			elapsed = 0;
		}
	}

	void OnGUI () {
		//画面サイズ変更チェック
		if (oldScrWidth != Screen.width || oldScrHeight != Screen.height) {
			LocateGUI();
		}
		oldScrWidth = Screen.width;
		oldScrHeight = Screen.height;

		//fps表示
		if (boxVisible) {
			GUI.Box(outer, "");
		}

		GUILayout.BeginArea(inner);
		{
			GUILayout.BeginVertical();
			GUILayout.Label("fps : " + fps.ToString("F1"));
			//↓たまに極端に大きな値が出るので使い勝手が悪い
			//GUILayout.Label("fps : " + (1f / Time.deltaTime).ToString("F1"));
			GUILayout.EndVertical();
		}
		GUILayout.EndArea ();
	}

	//表示位置を計算する
	void LocateGUI() {
		x = GetAlignedX(alignment, boxWidth);
		y = GetAlignedY(alignment, boxHeight);
		outer = new Rect(x, y, boxWidth, boxHeight);
		inner = new Rect(x + padding.x, y + padding.y, boxWidth, boxHeight);
	}

	//横位置の計算
	float GetAlignedX(Alignment anchor, float w) {
		switch (anchor) {
		default:
		case Alignment.LeftTop:
		case Alignment.LeftBottom:
			return offset.x;

		case Alignment.RightTop:
		case Alignment.RightBottom:
			return Screen.width - w - offset.x;
		}
	}

	//縦位置の計算
	float GetAlignedY(Alignment anchor, float h) {
		switch (anchor) {
		default:
		case Alignment.LeftTop:
		case Alignment.RightTop:
			return offset.y;

		case Alignment.LeftBottom:
		case Alignment.RightBottom:
			return Screen.height - h - offset.y;
		}
	}
}
