using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
{
    public GameObject player;
    bool Left = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //2.の部分
    void Update()
    {
        if (Left == true)
        {
            Vector3 PlayerPos = player.transform.localPosition;
            PlayerPos.x -= (1.0f * Time.deltaTime);
            if (PlayerPos.x < -2.73f) { PlayerPos.x = -2.73f; }
            player.transform.localPosition = PlayerPos;
        }
    }

    //1.の部分
    public void OnLD()
    {
        Left = true;
        animator.SetBool("Left", true);
    }

    //3.の部分
    public void OnLU()
    {
        Left = false;
        animator.SetBool("Left", false);

    }
}