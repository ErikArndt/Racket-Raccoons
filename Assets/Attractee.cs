using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractee : MonoBehaviour {

    public Rigidbody rb;

	public bool attracting = true;

    void Start()
    {

    }

    void Update()
    {
        if (ButtonScript.cbstate == ButtonScript.ButtonState.Attract)
        {
            attracting = true;
        }
        else if (ButtonScript.cbstate == ButtonScript.ButtonState.Repel)
        {
            attracting = false;
        }
    }
}
