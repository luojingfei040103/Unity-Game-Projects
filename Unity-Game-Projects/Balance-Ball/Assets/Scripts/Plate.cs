using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private Transform trans;

    private Rigidbody rigid;

    private int dir = 1;

    public float speed = 1;

    void Start()
    {
        trans = this.transform;
        rigid = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
        if (trans.position.x >= 7.4 && dir > 0)
            dir = -1;
        else if (trans.position.x <= -11 && dir < 0)
            dir = 1;
    }

    void FixedUpdate()
    {
        rigid.MovePosition(trans.position + trans.right * dir * Time.fixedDeltaTime * speed);
        //rigid.velocity = Vector3.forward * speed * Time.fixedDeltaTime * dir;
    }
}
