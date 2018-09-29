using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation (
			Vector3.forward, Camera.main.ScreenToWorldPoint (Input.mousePosition)-transform.position);
		if (Input.GetMouseButtonDown (0))
			rb.velocity = transform.up;
	}
}
