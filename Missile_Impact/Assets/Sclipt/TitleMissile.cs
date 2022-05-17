using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMissile : MonoBehaviour
{
    public float missileRotation;
    private Vector3 playerRot;
    private void MovingRestrictions()
    {
        this.playerRot = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, missileRotation * Time.deltaTime);

        this.MovingRestrictions();
    }
}
