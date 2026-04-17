using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private Transform trans;

    private Transform CannonBall;

    public Transform LaunchPoint;
    public int dir = -1;

    //public Transform shoot;

    public float speed=1;

    public float Force = 10;

   private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            CannonBall = other.transform;
            CannonBall.GetComponent<BallController>().enabled = false;
            CannonBall.gameObject.SetActive(false);
            CannonBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            CannonBall.position = this.transform.position;
        }
    }

    private void Start()
    {
        trans = this.transform;
    }
    
    void Update()
    {
        if (CannonBall != null)
        {
            trans.Rotate(Vector3.right * Input.GetAxis("Vertical") * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.G))
            {
                CannonBall.position = LaunchPoint.position;
                CannonBall.gameObject.SetActive(true);
                CannonBall.GetComponent<Rigidbody>().AddForce(Force*LaunchPoint.up, ForceMode.Impulse);
            }
        }
    } 

   
    //{
    //    if (ball == null)
    //        return;
    //    trans.Rotate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Vertical"));
    //    if (Input.GetKeyDown(KeyCode.F))
    //{
    //    ball.position = shoot.position;
    //        ball.gameObject.SetActive(true);
    //        ball.GetComponent<Rigidbody>().AddForce(Force * trans.up, ForceMode.Impulse);
    //    }
}
//void OnCollisionEnter(Collision collision)
//{
//if (collision.transform.CompareTag("Player"))
//{
//ball = collision.transform;
//ball.gameObject.SetActive(false);
//ball.position = gun.position;
//        }
//    }
//}
