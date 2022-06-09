using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    //ゲームオーバを表示するテキスト
    private GameObject scoreText;

    //加算スコア
    private int sStar = 100;
    private int lStar = 300;
    private int sCloud = 50;
    private int lCloud = 100;
    // 合計スコア
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        // スコアオブジェクト取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したモノによって得点を分ける
        if (collision.gameObject.tag == "SmallStarTag")
        {
            score += sStar;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            score += lStar;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            score += sCloud;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            score += lCloud;
        }

        this.scoreText.GetComponent<Text>().text = "Score：" + score;
    }
}