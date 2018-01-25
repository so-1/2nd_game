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
        
        

        if (col.tag == "Ballet")
        {
            // 弾の削除
            Destroy(col.gameObject);
            // 敵を削除
            Destroy(gameObject);
        }
        if (col.tag == "Player")
        {
            // プレイヤーの非常時
            col.gameObject.SetActive(false);
            
        }
    }

}
