using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed = 0.01f;
    public float rotationSpeed = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       BasicMovment();
       Turning();
    }

    private void Turning() {
        Vector3 rotate = new Vector3();

        if  (Input.GetKey(KeyCode.LeftArrow))
            rotate += new Vector3(0, -1, 0);

        if  (Input.GetKey(KeyCode.RightArrow))
            rotate += new Vector3(0, 1, 0);
        
        transform.Rotate(rotate * rotationSpeed);
        rotate *= 0;
    }
    private void BasicMovment() {
        //Vector3 force = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 force = new Vector3();

        if (Input.GetKey(KeyCode.W)) 
            force += new Vector3(0, 0, 1);

        if (Input.GetKey(KeyCode.S))
            force += new Vector3(0, 0, -1);

        if (Input.GetKey(KeyCode.D))
            force += new Vector3(1, 0, 0);

        if (Input.GetKey(KeyCode.A))
            force += new Vector3(-1, 0, 0);

        force.Normalize();
        //rb.AddForce(force * movementSpeed);
        rb.AddRelativeForce(force * movementSpeed);
        force *= 0;
    }
}
