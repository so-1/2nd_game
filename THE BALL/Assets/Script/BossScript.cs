﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    int BosHP = 30;
    float moveX = 4.5f;
    Animation anim;
	// Use this for initialization
	void Start () {
        anim = this.gameObject.GetComponent<Animation>();
    }

    void Update()
    {
       

        Move();

    }
    private void Move()
    {
        float LimitX = Random.Range(-0.03f, 0.03f);
        if (LimitX >= 0)
        {
            //自分のy位置を＋方向に毎回「0.03f」ずつ移動させる。
            this.transform.position += new Vector3(moveX*Time.deltaTime, 0, 0);
        }
        if (LimitX < 0)
        {
            //自分のy位置を＋方向に毎回「0.03f」ずつ移動させる。
            this.transform.position -= new Vector3(moveX * Time.deltaTime, 0, 0);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        // 弾の削除
        Destroy(col.gameObject);
        Vector3 Obj = GetComponent<Transform>().localScale;
        this.transform.localScale = new Vector3(Obj.x -= 0.01f,Obj.y -= 0.01f,Obj.z -= 0.01f);
        BosHP--;
        anim.Play();

        // プレイヤーを削除

        if (BosHP <=0) {
            Destroy(gameObject);
        }
     
    }
}