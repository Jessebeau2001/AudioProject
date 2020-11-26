using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class WallBump : MonoBehaviour
{
    public string wallTag;
    public float distanceMod = 4f;
    public bool audibleBumps = true;
    public AudioSource src;
    void Start()
    {
        //audioData = GetComponent<AudioSource>();
    }   

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == wallTag) {
            ContactPoint contact = collision.contacts[0];
            Vector3 direction = contact.point - transform.position;
            direction.y = 0; //Ignore verticality
            direction.Normalize();
            Debug.DrawRay(transform.position, direction * distanceMod);
            AudioSource.PlayClipAtPoint(src.clip, transform.position + (direction * distanceMod));
        }
    }
}
// Check for collision with wall    | Check
// Check for collision points       | Check
// Draw vector towards point        | Check
// Nomrlalize it                    | Check
// Play directional audio file at end point of vector | Check

//make is so bumping into different objects make different sounds for door etc