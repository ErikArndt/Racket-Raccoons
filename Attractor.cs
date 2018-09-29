using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    // Adapted from code by Brackeys
    // https://www.youtube.com/watch?v=Ouu3D_VHx9o

    const float G = 1;

    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Attractee[] attractees = FindObjectsOfType<Attractee>();
        foreach (Attractee attractee in attractees)
        {
            if (attractee != this)
            {
                Attract(attractee);
            }
        }
    }

    void Attract(Attractee objectToAttract)
    {
        Rigidbody2D rbToAttract = objectToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector2 force = direction; // initialization
        if (objectToAttract.attracting) {
            force = direction.normalized * forceMagnitude;
        } else
        {
            force = direction.normalized * forceMagnitude * -1;
        }
        

        rbToAttract.AddForce(force);
    }
}
