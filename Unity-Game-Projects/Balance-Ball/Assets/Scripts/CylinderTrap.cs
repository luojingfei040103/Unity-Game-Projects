using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTrap : MonoBehaviour
{
    public Rigidbody[] Cylinder;
    
    public Rigidbody Plate;

    public GameObject Land;

    public float speed=3;
   
    private bool isFinish;

    private bool SpeedEnough{
        get
        {
            for (int i = 0; i < Cylinder.Length; i++)
            {
                if (Cylinder[i].angularVelocity.y > 5)
                    return true;
            }
            return false;
        }
    }
    void Update()
    {
        if(SpeedEnough && !isFinish)
        {
            isFinish = true;
            for (int i = 0; i < Cylinder.Length; i++)
            {
                Cylinder[i].gameObject.SetActive(false);
            }
            Land.SetActive(true);
            Plate.isKinematic = false;
        }
        if (isFinish)
        {
            Plate.velocity = Vector3.up * speed;
        }
    }
}
