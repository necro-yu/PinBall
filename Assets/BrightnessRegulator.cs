using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessRegulator : MonoBehaviour
{
    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject scoreText;
    // Material������
    Material myMaterial;

    // Emission�̍ŏ��l
    private float minEmission = 0.2f;
    // Emission�̋��x
    private float magEmission = 2.0f;
    // �p�x
    private int degree = 0;
    //�������x
    private int speed = 5;

    //���Z�X�R�A
    private int sStar = 100;
    private int lStar = 300;
    private int sCloud = 50;
    private int lCloud = 100;
    // ���v�X�R�A
    private int score = 0;

    // �^�[�Q�b�g�̃f�t�H���g�̐F
    Color defaultColor = Color.white;

    // Use this for initialization
    void Start()
    {
        // �X�R�A�I�u�W�F�N�g�擾
        this.scoreText = GameObject.Find("ScoreText");

        // �^�O�ɂ���Č��点��F��ς���
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        //�I�u�W�F�N�g�ɃA�^�b�`���Ă���Material���擾
        this.myMaterial = GetComponent<Renderer>().material;

        //�I�u�W�F�N�g�̍ŏ��̐F��ݒ�
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
    }

    // Update is called once per frame
    void Update()
    {

        if (this.degree >= 0)
        {
            // ���点�鋭�x���v�Z����
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            // �G�~�b�V�����ɐF��ݒ肷��
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //���݂̊p�x������������
            this.degree -= this.speed;
        }
    }

    //�Փˎ��ɌĂ΂��֐�
    void OnCollisionEnter(Collision other)
    {
        //�p�x��180�ɐݒ�
        this.degree = 180;

        // �Փ˂������m�ɂ���ē��_�𕪂���
        if (tag == "SmallStarTag")
        {
            score += sStar;
        }
        else if (tag == "LargeStarTag")
        {
            score += lStar;
        }
        else if (tag == "SmallCloudTag")
        {
            score += sCloud;
        }
        else if (tag == "LargeCloudTag")
        {
            score += lCloud;
        }

        this.scoreText.GetComponent<Text>().text = "Score�F" + score;
    }
}
