using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRight : MonoBehaviour
{
    public GameObject player;
    bool Right = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //2.の部分
    void Update()
    {
        if (Right == true)
        {
            Vector3 PlayerPos = player.transform.localPosition;
            PlayerPos.x += (2.0f * Time.deltaTime);
            if (PlayerPos.x > 2.73f) { PlayerPos.x = 2.73f; }
            player.transform.localPosition = PlayerPos;
        }
    }

    //1.の部分
    public void OnRD()
    {
        Right = true;
        animator.SetBool("Right", true);
    }

    //3.の部分
    public void OnRU()
    {
        Right = false;
        animator.SetBool("Right", false);
     
    }
}
