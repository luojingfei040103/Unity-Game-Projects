using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class CameraTrace : MonoBehaviour
{
    private Transform trans;
    public Transform Target;
    public Vector3 dis = new Vector3(0, 2, -5);
    void Start()
    {
        trans = this.transform;
    }

    void Update()
    {
        trans.position = Target.position + dis;
        trans.LookAt(Target);
    }
}
