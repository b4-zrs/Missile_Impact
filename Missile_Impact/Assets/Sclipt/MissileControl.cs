using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    private float miuTurnInputValue;
    private Rigidbody miuRb;

    private float miuNoseInputValue;



    // Start is called before the first frame update
    void Start()
    {
        miuRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 前進は自動
        transform.Translate(0f, 3f * Time.deltaTime, 0f);

        // 旋回
        miuTurnInputValue = Input.GetAxis("Horizontal");
        float turn = miuTurnInputValue * 100 * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        miuRb.MoveRotation(miuRb.rotation * turnRotation);

        // 機首（上昇、下降）
        miuNoseInputValue = Input.GetAxis("Vertical");
        float noseTurn = miuNoseInputValue * 30 * Time.deltaTime;
        Quaternion turnNoseRotation = Quaternion.Euler(noseTurn, 0, 0);
        miuRb.MoveRotation(miuRb.rotation * turnNoseRotation);
    }
}
