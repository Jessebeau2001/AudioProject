using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBump : MonoBehaviour
{
    public AudioSource audioData;
    public bool audibleBumps = true;
    void Start()
    {
        //audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Wall") {
            audioData.Play(0);
        }
    }
}

// Check for collision with wall
// Check for collision point
// Draw vector towards point
// Nomrlalize it
// Play directional audio file at end point of vector