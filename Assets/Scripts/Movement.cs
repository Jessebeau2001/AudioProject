using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private readonly System.Random random = new System.Random();
    private AudioSource footstep;
    private Rigidbody rb;
    private Collider triggerCol;
    public float movementModifier = 220f;
    public float turnModifier = 1f;
    public int StandardStepInterval = 100;
    private int CurrentStepInterval;
    public bool canTurn = true;
    public bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Transform footstepObj = transform.Find("Footstep");
        if (footstepObj == null) throw new System.Exception("Footstep SoundSource could not be found");
            else footstep = footstepObj.GetComponent<AudioSource>();

        CurrentStepInterval = StandardStepInterval;
    }

    void FixedUpdate()
    { //Fixed physics update for, u guessed it, physics
        if (canMove)
            ControllerMovement();
            //BasicMovment();
        
        if (canTurn)
            StaticTurning();
            //RigidTurning();

        Footsteps();
    }

    void Update()
    { //Normal update for Keypress
        if (Input.GetKeyDown(KeyCode.Space) && triggerCol != null) {
            IInteractable thing = triggerCol.GetComponent(typeof(IInteractable)) as IInteractable;
            if (thing == null || !((MonoBehaviour) thing).enabled) return;
            Debug.Log("Trying to access OBJ with Interface Interactable: " + thing.GetType().FullName);
            thing.Interact();
        }
    }

    void Footsteps() { 
        float velocity = rb.velocity.magnitude;
        CurrentStepInterval -= (int) Mathf.Floor(velocity);
        Debug.Log(CurrentStepInterval);

        if (CurrentStepInterval < 0) {
            CurrentStepInterval += StandardStepInterval;
            footstep.pitch = (float) RandomDouble(0.8, 1.2);
            footstep.Play();
        }
    }

    public double RandomDouble(double min, double max) {
        return random.NextDouble() * (max - min) + min;
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

    private void ControllerMovement() {
        Vector3 force = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        force.Normalize();
        rb.AddRelativeForce(force * movementModifier * Time.deltaTime);
        force *= 0;
    }

    public void ToggleMovement() {
        canMove = !canMove;
    }

    void OnTriggerEnter(Collider col) {
        triggerCol = col;
    }

    void OnTriggerExit() {
        triggerCol = null;
    }
}
