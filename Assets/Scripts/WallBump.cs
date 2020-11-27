using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class WallBump : MonoBehaviour
{
    public float distanceMod = 4f;
    public bool audibleBumps = true;
    public AudioSource wallAudio;
    public AudioSource doorAudio;
    public AudioSource bedAudio;
    void Start()
    {
        //audioData = GetComponent<AudioSource>();
    }   

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        Vector3 direction = contact.point - transform.position;
        direction.y = 0; //Ignore verticality
        direction.Normalize();
        Debug.DrawRay(transform.position, direction * distanceMod);
        
        //for now audio sources are hardcoded here instead of tied to the object you bounce into NEED TO CHANGE THIS LATER (Something like other.GetComponent<AudioSource>.clip)
        switch (collision.collider.tag) {
            case "Wall":
                AudioSource.PlayClipAtPoint(wallAudio.clip, transform.position + (direction * distanceMod));
                break;
            case "Door":
                AudioSource.PlayClipAtPoint(doorAudio.clip, transform.position + (direction * distanceMod));
                break;
            case "Bed":
                AudioSource.PlayClipAtPoint(bedAudio.clip, transform.position + (direction * distanceMod));
                break;

        }
    }
}
// Check for collision with wall    | Check
// Check for collision points       | Check
// Draw vector towards point        | Check
// Nomrlalize it                    | Check
// Play directional audio file at end point of vector | Check

//make is so bumping into different objects make different sounds for door etc