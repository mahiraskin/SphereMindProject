using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    public GameObject aim;
    // referans obje, sapan mekaniðinde parmak 
  
    public GameObject ball;
    // etkileþimleri görmeniz için yöneleceði top


    public float speed = 160.0f; 
    private Rigidbody rb;
    //public float mass;

    void Start()
    {

        rb = GetComponent<Rigidbody>(); 

        Vector3 angle = (this.transform.position - aim.transform.position).normalized;
        Vector3 movement = angle * speed; 
        rb.velocity = movement;

       

            /*
            Vector3 sil = aim.transform.position;
            Vector3 dir = (this.transform.position - aim.transform.position).normalized;
            Debug.DrawLine(sil, sil + dir * 10, Color.red, Mathf.Infinity);
            */

            // rb.velocity = Vector3(0, 10, 0);
            // rb.AddForce(0, 10, 0);


        }

    void Update()
    {
        // etkileþimleri görmeniz için hareket
        if (rb.velocity.magnitude < 1 )
        {
            Vector3 angle1 = (ball.transform.position - this.transform.position).normalized;
            Vector3 movement1 = angle1 * speed;
            rb.velocity = movement1;
        }
    }
}
