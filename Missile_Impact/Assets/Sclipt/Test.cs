using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //�J�����I�u�W�F�N�g
    public GameObject mainCamera;

    //z���𒲐��B���̐��Ȃ�v���C���[�̑O�ɁA���̐��Ȃ�v���C���[�̌��ɔz�u����
    public int zAdjust = 5;

    void Update()
    {
        //�J�����̓v���C���[�Ɠ����ʒu�ɂ���
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

