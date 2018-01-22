using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultScript : MonoBehaviour
{
	// インスペクターから死因画像を登録するpublicインスタンスメンバ
	public Sprite[] deathImageList;

	// 死亡理由（理由ID）を記憶するクラスメンバ（0なら釣られた、1なら食べられた）
	public static int reason;

	// ゲーム画面で泳いだ距離を記憶するクラスメンバ
	public static float distance;


	void Start ()
	{
		// 外部から指定された理由IDをnowReason変数に代入
		int nowReason = reason;

		// 不具合対策：もし0未満の値が入っていたら0にする
		if (nowReason < 0) {
			nowReason = 0;
		}

		// 不具合対策：もしdeathImageListのサイズより大きい値が入っていたら0に戻す
		if (deathImageList.Length <= nowReason) {
			nowReason = 0;
		}

		// 釣られた場合の処理
		if (0 == nowReason) {
			// TextReasonゲームオブジェクトのテキストを書き換える
			GameObject.Find ("TextReason").GetComponent<Text> ().text 
			= "釣られた！";

			// DeathImageゲームオブジェクトの画像を差し替える
			GameObject.Find ("DeathImage").GetComponent<Image> ().sprite 
			= deathImageList [0];
		}

		// 食べられた場合の処理
		if (1 == nowReason) {
			// TextReasonゲームオブジェクトのテキストを書き換える
			GameObject.Find ("TextReason").GetComponent<Text> ().text 
			= "食べられた！";

			// DeathImageゲームオブジェクトの画像を差し替える
			GameObject.Find ("DeathImage").GetComponent<Image> ().sprite 
			= deathImageList [1];
		}

		// ゲーム画面で進んだ距離をTextDistanceに表示
		GameObject.Find ("TextDistance").GetComponent<Text> ().text = "記録:" 
			+ (int)distance + "m";
	}


	public void Update ()
	{
		// 画面のどこかを左クリックしたらゲームシーンへ遷移します。
		if (Input.GetMouseButtonDown (0)) {
			UnityEngine.SceneManagement.SceneManager
				.LoadSceneAsync ("GameScene");
		}
	}

}
