using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    private Rigidbody rigid;

    public float speed = 5;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        rigid.angularVelocity = Vector3.up * speed;
    }
}
