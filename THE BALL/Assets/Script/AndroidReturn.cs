using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidReturn : MonoBehaviour
{



    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // エスケープキー取得
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //ダイアログ開く
                DialogOpen();
            }
        }
    }


    void DialogOpen()
    {
        //ラベルをセット
        DialogManager.Instance.SetLabel("Yes", "No", "Close");

        // YES NO ダイアログ
        DialogManager.Instance.ShowSelectDialog(
            "アプリを終了しますか？",
            (bool result) =>
            {
                Debug.Log("result:" + result.ToString());
                //Yesを押したら終了
                if (result)
                    Application.Quit();
            }
        );
    }
}