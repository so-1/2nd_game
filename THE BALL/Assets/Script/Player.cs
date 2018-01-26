using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // 移動スピード
    public float speed = 5;
    float moveY = 0.03f;

    // PlayerBulletプレハブ
    public GameObject bullet;
    /*
    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            // 0.05秒待つ
            yield return new WaitForSeconds(0.05f);
        }
    }
    */
    void Start()
    {

    }

    public void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void Move()
    {
        //自分のy位置を＋方向に毎回「0.03f」ずつ移動させる。
        this.transform.position += new Vector3(0, moveY, 0);
    }



    void Update()
    {

        Move();
        moveY += 0.0001f;

        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

   void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.tag == "Enemy")
        {
            //Destroy(col2.gameObject);
            //Invoke("SceneRestart", 3.5f);
            GameObject CanvasObj = GameObject.Find("Canvas");
            GameObject gameObject = CanvasObj.transform.Find("GameOver").gameObject;
            gameObject.SetActive(true);

            GameObject Retry = CanvasObj.transform.Find("RetryButton").gameObject;
            Retry.SetActive(true);

            GameObject Left = CanvasObj.transform.Find("LeftButton").gameObject;
            Left.SetActive(false);
            GameObject Right = CanvasObj.transform.Find("RightButton").gameObject;
            Right.SetActive(false);
            GameObject Fire = CanvasObj.transform.Find("Fire").gameObject;
            Fire.SetActive(false);


        }

    }
    public void SceneRestart()
    {
        // 現在のシーン番号を取得
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 現在のシーンを再読込する
        SceneManager.LoadScene(sceneIndex);
    }
}