using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject target;
    private Vector3 distance;

    void Start()
    {
        distance.z = transform.position.z - target.transform.position.z;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(0, 0, target.transform.position.z + distance.z);

    }
}