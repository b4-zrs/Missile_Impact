using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class ScoreManager : MonoBehaviour
{
    private double scoreTime ;

    public GameObject scoreObject = null; // Textオブジェクト

    // 初期化
    void Start()
    {
        
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text scoreText = scoreObject.GetComponent<Text>();
        // テキストの表示を入れ替える

        Debug.Log(Time.deltaTime);
        Debug.Log(Time.frameCount);
        scoreTime += Time.deltaTime*10; 

        scoreText.text = "Score : " + scoreTime.ToString("#0.0");
    }
}