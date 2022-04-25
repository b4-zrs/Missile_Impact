using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //カメラオブジェクト
    public GameObject mainCamera;

    //z軸を調整。正の数ならプレイヤーの前に、負の数ならプレイヤーの後ろに配置する
    public int zAdjust = 5;

    void Update()
    {
        //カメラはプレイヤーと同じ位置にする
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zAdjust);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
        }
    }

}

