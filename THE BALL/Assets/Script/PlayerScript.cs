using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Animator animator;
    public float moveX = 30f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
        public void LeftMovein()
    {
        //自分のy位置を－方向に毎回「0.03f」ずつ移動させる。
        this.transform.position -= new Vector3(moveX, 0, 0);
        animator.SetBool("Left", true);

    }
    public void LeftMoveOut()
    {
        animator.SetBool("Left", false);
    }


}
