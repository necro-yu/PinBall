using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;
    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject scoreText;

    //���Z�X�R�A
    private int sStar = 100;
    private int lStar = 300;
    private int sCloud = 50;
    private int lCloud = 100;
    // ���v�X�R�A
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");
        // �X�R�A�I�u�W�F�N�g�擾
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂������m�ɂ���ē��_�𕪂���
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

        this.scoreText.GetComponent<Text>().text = "Score�F" + score;
    }
}