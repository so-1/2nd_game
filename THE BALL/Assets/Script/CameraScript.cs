using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GameObject Player = GameObject.Find("PLAYER");
        if (null == Player)
        {
            return;
        }
        Vector3 playerPos = Player.transform.position;
        Vector3 cameraPos = this.transform.position;
        cameraPos.y = playerPos.y + 3;
        this.transform.position = cameraPos;
	}
}
