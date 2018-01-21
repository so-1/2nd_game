using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D col)
    {
        // 弾の削除
        Destroy(col.gameObject);
        

        // プレイヤーを削除
        Destroy(gameObject);
    }

}
