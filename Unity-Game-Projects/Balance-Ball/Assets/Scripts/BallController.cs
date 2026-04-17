using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 dir;
    public float Force = 5f;
    public float Torque = 10f;
    private bool brake;
    private int spin;
    private void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        brake = Input.GetKey(KeyCode.Space);
        if (Input.GetKey(KeyCode.Q))
            spin = -1;
        else if (Input.GetKey(KeyCode.E))
            spin = 1;
        else
            spin = 0;
    }
    private void FixedUpdate()
    {
        if (!brake) { 
            rigid.AddForce(dir * 50, ForceMode.Force);
            rigid.AddTorque(Vector3.up * spin * Torque); 
        }  else
            rigid.velocity = Vector3.Lerp(rigid.velocity, new Vector3(0, rigid.velocity.y, 0), 0.2f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            foreach(Transform child in other.transform.parent)
            {
                child.GetComponent<Rigidbody>().AddExplosionForce(100, other.contacts[0].point, 5, 3);
            }
        }
    }
}
