using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // �ǉ����܂��傤

public class ScoreManager : MonoBehaviour
{
    private double scoreTime ;

    public GameObject scoreObject = null; // Text�I�u�W�F�N�g

    // ������
    void Start()
    {
        
    }

    // �X�V
    void Update()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text scoreText = scoreObject.GetComponent<Text>();
        // �e�L�X�g�̕\�������ւ���

        Debug.Log(Time.deltaTime);
        Debug.Log(Time.frameCount);
        scoreTime += Time.deltaTime*10; 

        scoreText.text = "Score : " + scoreTime.ToString("#0.0");
    }
}