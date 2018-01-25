using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    int BosHP = 10;
    float moveX = 4.5f;

    // Use this for initialization
    void Start()
    {
       
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
            this.transform.position += new Vector3(moveX * Time.deltaTime, 0, 0);
        }
        if (LimitX < 0)
        {
            //自分のy位置を＋方向に毎回「0.03f」ずつ移動させる。
            this.transform.position -= new Vector3(moveX * Time.deltaTime, 0, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        BosHP--;
        Destroy(col.gameObject);
        gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        if (BosHP < 0)
        {
            Destroy(this.gameObject);
        }

    }
}
