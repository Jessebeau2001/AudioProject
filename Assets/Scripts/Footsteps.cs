using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private readonly System.Random rnd = new System.Random();
    private AudioSource src;
    public AudioClip[] StepSounds;
    public int StandardStepInterval = 150;
    private int CurrentStepInterval;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        src = GetComponent<AudioSource>();

        CurrentStepInterval = StandardStepInterval;
    }

    void FixedUpdate()
    {
        FixedFootstep();
    }

    void FixedFootstep() { 
        float velocity = rb.velocity.magnitude;
        CurrentStepInterval -= (int) Mathf.Floor(velocity);
        Debug.Log(CurrentStepInterval);

        if (CurrentStepInterval < 0) {
            CurrentStepInterval += StandardStepInterval;
            src.pitch = (float) RandomDouble(0.8, 1.2);
            src.clip = StepSounds[rnd.Next(StepSounds.Length)];
            src.Play();
        }
    }

    public double RandomDouble(double min, double max) {
        return rnd.NextDouble() * (max - min) + min;
    }
}
