using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    
    public float movementModifier = 0.01f;
    public float turnModifier = 0.5f;
    public bool canTurn = true;
    public bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
            //ControllerMovement();
            BasicMovment();
        
        if (canTurn)
            StaticTurning();
            //RigidTurning();
    }

    private void StaticTurning() {
        Vector3 rotate = new Vector3();

        if  (Input.GetKey(KeyCode.LeftArrow))
            rotate += new Vector3(0, -1, 0);

        if  (Input.GetKey(KeyCode.RightArrow))
            rotate += new Vector3(0, 1, 0);

        transform.Rotate(rotate * turnModifier);

        rotate *= 0;
    }

    private void RigidTurning() {
        Vector3 rotate = new Vector3();

        if  (Input.GetKey(KeyCode.LeftArrow))
            rotate += new Vector3(0, -1, 0);

        if  (Input.GetKey(KeyCode.RightArrow))
            rotate += new Vector3(0, 1, 0);
        
        //transform.Rotate(rotate * rotationSpeed);
        rb.AddTorque(rotate * turnModifier);
        rotate *= 0;
    }

    private void BasicMovment() {
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
        rb.AddRelativeForce(force * movementModifier);
        force *= 0;
    }

    private void ControllerMovement() {
        Vector3 force = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        force.Normalize();
        rb.AddRelativeForce(force * movementModifier);
        force *= 0;
    }

    public void ToggleMovement() {
        canMove = !canMove;
    }
}
