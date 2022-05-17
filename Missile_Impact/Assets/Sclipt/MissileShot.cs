using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShot : MonoBehaviour
{
    public float shottingSpeed = 10;
    private bool misBool = false;

    // Update is called once per frame
    void Update()
    {
        if (misBool == true)
        {
            transform.Translate(0f, shottingSpeed * Time.deltaTime, shottingSpeed * Time.deltaTime);
        }
    }

    public void PushButton()
    {
        StartCoroutine(Shot());

    }

    private IEnumerator Shot()
    {
        yield return new WaitForSeconds(1.0f);
        MissileMove();
    }

    private void MissileMove()
    {
        misBool = true;
    }
}