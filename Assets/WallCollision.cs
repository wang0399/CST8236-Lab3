using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour
{
    public GameObject wallPieces;
    public ParticleSystem wallParticle; 

    public void OnCollisionEnter(Collision collision)
    {
        //Avoid making the sound at the start, as the objects were "dropping" into their default posiiton on the ground   
        if (collision.gameObject.name.Equals("8Ball") || collision.gameObject.name.Equals("Roof"))
        {          
            // Check to see if the object has audio source
            AudioSource objectWeHitAudio = this.gameObject.GetComponent<AudioSource>();
            if (objectWeHitAudio != null)
            {
                // If so, play it!
                objectWeHitAudio.Play();
            }
            //Instantiate the wall pieces and particle systems when collision occur
                Instantiate(wallPieces, transform.position, transform.rotation);
                Instantiate(wallParticle, collision.transform.position, collision.transform.rotation);
                Destroy(this.gameObject);          
        }
    }
}
