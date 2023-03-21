using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : NetworkBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody rb;

    private bool isShoot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        //if isShoot is true, then the ball is already shot. Wait for it to stop moving.
        //after it has stopped moving, we can shoot again.
        if(isShoot && rb.velocity.magnitude < 0.1f)
        {
            isShoot = false;
        }
    }
    private void OnMouseDown() 
    {
       // mousePressDownPos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
        mousePressDownPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
    }

    private void OnMouseUp()
    {
        // mouseReleasePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
        mouseReleasePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Debug.Log("mouseReleasePos: " + mouseReleasePos);
        Debug.Log("mousePressDownPos: " + mousePressDownPos);
        Vector3 force = mouseReleasePos - mousePressDownPos;
        Debug.Log("force: " + force);
        Shoot(force*1000);
    }

    private float forceMultiplier = 3;
    void Shoot(Vector3 force)
    {
        if(isShoot)    
            return;
        
        Vector3 forceVector = new Vector3(force.x, 0, force.z);
        forceVector = -forceVector;
        Debug.Log("forceVector: " + forceVector);
        //delete this later
        if (IsOwner)
        {
            rb.AddForce(forceVector * forceMultiplier);
        }
        isShoot = true;
    }
}
