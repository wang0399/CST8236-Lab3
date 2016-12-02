using UnityEngine;
using System.Collections;

public class DirectionControl : MonoBehaviour {

    //movement vector of the ball
    private Vector3 ballMovement;

    private ParticleSystem ballParticle;

    //ball speed
    public float ballSpeed = 10.0f; //default speed

    //holds reference to the rididbody of the sphere
    private Rigidbody ballRb;

	// Use this for initialization
	void Start () {
        ballRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        //get horizontal and vertical (in this case x and z movements) from keyboard
        float ballHorMovement = Input.GetAxis("Horizontal");
        float ballVerMovement = Input.GetAxis("Vertical");

        ballMovement = new Vector3(ballHorMovement, 0.0f, ballVerMovement); //only move the ball in x and z axis
        ballRb.AddForce(ballMovement * ballSpeed); //apply force to the ball's rigid body
       
    }

    public void OnCollisionEnter(Collision collision)
    {  
        //Avoid making the sound at the start, as the objects were "dropping" into their default posiiton on the ground   
        if (!collision.gameObject.name.Equals("Ground"))
        {              
            //create localized explosive force near the point of impact
            Rigidbody collisionRb;
            collisionRb = collision.gameObject.GetComponent<Rigidbody>();
            collisionRb.AddExplosionForce(2.0f, collision.transform.position,1.0f,100.0f);
            // Check to see if the object has audio source
            AudioSource objectWeHitAudio = collision.gameObject.GetComponent<AudioSource>();
            if (objectWeHitAudio != null)
            {
                // If so, play it!
                objectWeHitAudio.Play();
            }
        }
    }
}
