using UnityEngine;
using System.Collections;

public class roofCrash : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Roof") || collision.gameObject.name.Equals("RoofPiece"))
        {
            Debug.Log("Roof Crashed");
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100000.0f, collision.transform.position, 1.0f, 1.0f);
        }
    }
}
