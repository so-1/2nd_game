using UnityEngine;
using System.Collections;

public class GameMasterScript : MonoBehaviour
{
	// ゲーム内に登場する敵キャラクターのリストのpublicインスタンスメンバ
	public GameObject[] enemyList;

	// 敵キャラクター出現の判定用エネルギーを記録するインスタンスメンバ
	float energy = 0;

	// エネルギーがこの値を超えると敵キャラクターが出現する
	// 敵キャラクターの出現頻度を多くしたければ少なめに、出現頻度少なくしたければ多めに調整
	float LIMIT = 1;

	// 最後にチェックした時のx座標を記録するインスタンスメンバ
	float lastY = 0;

	void Update ()
	{
		// 敵キャラを出現させるメソッドを呼び出す
		EnemyAppend ();

		// スコアを表示するメソッドを呼び出す
		// ScoreDisplay ();

		// ハイスコアを表示するメソッドを呼び出す
		// HighScoreDisplay ();

		// 主人公の生存状態を確認
		// CheckHeroLive ();
	}

	// 敵キャラクターを出現させるメソッド
	void EnemyAppend (){
		// メインカメラを取得
		Camera camera = Camera.main;

		// メインカメラのx座標を取得
		float nowY = camera.transform.position.y;

		// 前フレームでチェックしたx座標と現在のx座標の差をpowerに代入
		float power = nowY - lastY;

		// energyにpowerを加算します。
		energy += power;

		// チェック用のx座標を更新しておく
		lastY = nowY;


		// エネルギーがLIMITを超えてるか判定
		if (LIMIT < energy) {
			// エネルギーを0に戻す
			energy = 0;

			// 0〜敵キャラクターリストの長さ-1の乱数を求め、出現させる敵キャラクターを決める
			int idx = (int)(Random.value * 99999) % enemyList.Length;

			// 乱数を元に決めた敵キャラクターのゲームオブジェクトをリストから取得
			GameObject obj = enemyList [idx];

			// 敵キャラクターの出現位置を決めるために、新しいVector3を作成
			Vector3 pos = new Vector3 (0, 0, 0);

			// X座標は、カメラの撮影範囲から少しだけ右の座標を出現位置として取得
			pos.y = (Camera.main.ViewportToWorldPoint (new Vector2 (0, 1.4f)).y);

			// Y座標はカメラと同じ座標にする
			pos.x = camera.transform.position.x;

			// 敵キャラクターのゲームオブジェクトを作成
			Instantiate (obj, pos, Quaternion.identity);
		}
	}
    /*
	// スコアを表示するメソッド
	void ScoreDisplay ()
	{
		// 主人公のゲームオブジェクトを取得
		GameObject hero = GameObject.Find ("HERO");

		// 主人公の生存確認（食べられたあとはnullになる）
		if (null == hero) {
			return;
		}

		// 主人公のx座標を取得し、泳いだ距離とする
		float swimDistance = hero.transform.position.x;

		// スコアのゲームオブジェクトを取得
		GameObject score = GameObject.Find ("Score");

		// テキストコンポーネントを取得
		UnityEngine.UI.Text textComponent 
		= score.GetComponent<UnityEngine.UI.Text> ();

		// テキストコンポーネントのテキストに主人公のx座標を距離として出力
		// 小数点以下が表示されないようにint型に変換し、距離の単位として「m」を追加しておく
		textComponent.text = "Score:" + (int)swimDistance + "m";
	}

	// ハイスコア保存用のインスタンスメンバ
	float highScore = 0;

	// ハイスコアを表示するメソッド
	void HighScoreDisplay ()
	{
		// 主人公のゲームオブジェクトを取得
		GameObject hero = GameObject.Find ("HERO");

		// 主人公の生存確認（食べられたあとはnullになる）
		if (null == hero) {
			return;
		}

		// 主人公のx座標を取得し、泳いだ距離とする
		float swimDistance = hero.transform.position.x;

		// 泳いだ距離がハイスコアより大きければ、ハイスコアを更新
		if (highScore < swimDistance) {
			highScore = swimDistance;
		}

		// ハイスコアのゲームオブジェクトを取得
		GameObject score = GameObject.Find ("HighScore");

		// テキストコンポーネントを取得
		UnityEngine.UI.Text textComponent 
		= score.GetComponent<UnityEngine.UI.Text> ();

		// テキストコンポーネントのテキストに主人公のx座標を距離として出力
		// 小数点以下が表示されないようにint型に変換し、距離の単位として「m」を追加しておく
		textComponent.text = "HighScore:" + (int)highScore + "m";
	}


	// GameScene終了時に実行されるメソッド
	void OnDisable ()
	{
		// PlayerPrefsクラスを使って"HighScore"という名前でhighScoreインスタンスメンバの情報を保存
		PlayerPrefs.SetFloat ("HighScore", highScore);
	}

	// GameSceneが起動した直後に実行されるメソッド
	void OnEnable ()
	{
		// PlayerPrefsクラスを使って"HighScore"という名前のデータを探し、highScoreインスタンスメンバに代入
		highScore = PlayerPrefs.GetFloat ("HighScore", 0);
	}

	// 主人公が死んでから経過した時間
	float deathTimer = 0;

	// 主人公の生存状態を確認
	void CheckHeroLive ()
	{
		// 主人公のゲームオブジェクトを探す
		GameObject hero = GameObject.Find ("HERO");

		// 主人公の生存確認（食べられたあとはnullになる）
		if (null != hero) {

			//生きているときに泳いでいる距離をリザルトシーンに伝える。
			ResultScript.distance = hero.transform.position.x;

			// 主人公が生きていたらここでメソッドを終了
			return;
		}

		// 主人公が死んでいたら、タイマーにdeltaTimeを足す
		deathTimer += Time.deltaTime;

		// 死んでから3秒経過したらリザルトシーンに移動
		if (3 <= deathTimer) {
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync
				("ResultScene");
		}
	}
    */
}
