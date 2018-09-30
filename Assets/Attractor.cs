using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    // Adapted from code by Brackeys
    // https://www.youtube.com/watch?v=Ouu3D_VHx9o

    const float G = 1;

    public Rigidbody rb;

    public float gravRadius = 5;

    public GameObject Ring;
    public Sprite sprRed, sprBlue;
    private SpriteRenderer Ringspr;

    private void Start()
    {
        GameObject ring = Instantiate(Ring);
        ring.transform.position = transform.position;
        ring.transform.localScale *= gravRadius * 2;
        Ringspr = ring.GetComponent<SpriteRenderer>();
    }

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


        if (ButtonScript.cbstate == ButtonScript.ButtonState.Repel)
        {
            Ringspr.sprite = sprRed;
        }
        else
        {
            Ringspr.sprite = sprBlue;
        }
    }

    void Attract(Attractee objectToAttract)
    {
        Rigidbody rbToAttract = objectToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;
        
        if (distance <= gravRadius)
        {
            float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

            Vector3 force = direction; // initialization
            if (objectToAttract.attracting)
            {
                force = direction.normalized * forceMagnitude;
            }
            else
            {
                force = direction.normalized * forceMagnitude * -1;
            }


            rbToAttract.AddForce(force);
        }
    }
}
