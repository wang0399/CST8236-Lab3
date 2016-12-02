using UnityEngine;
using System.Collections;

public class roofCollision : MonoBehaviour {

    public GameObject roofPieces;

    public void OnCollisionEnter(Collision collision)
    {
        //Avoid making the sound at the start, as the objects were "dropping" into their default posiiton on the ground   
        if (collision.gameObject.name.Equals("Ground")) //only "break" the roof if it collides with ground
        {
            // Check to see if the object has audio source
            AudioSource objectWeHitAudio = this.gameObject.GetComponent<AudioSource>();
            if (objectWeHitAudio != null)
            {
                // If so, play it!
                objectWeHitAudio.Play();
            }
            //Instantiate broken roof pieces
            Instantiate(roofPieces, transform.position, transform.rotation);       
            Destroy(this.gameObject);        
        }
    }
}
