using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public Camera myCamera;
	public float elasticity;
	private Rigidbody2D rb;
	private bool isDragging;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
	}

	IEnumerator DeathAnim () {
		while (transform.localScale.x > 0.05f) {
			transform.localScale *= 0.9f;
			transform.Rotate (new Vector3 (0, 0, 10));
			yield return null;
		}
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isDragging) {
			transform.position = myCamera.ScreenToWorldPoint (Input.mousePosition);
			Vector3 newPos = transform.position;
			newPos.z = 0;
			transform.position = newPos;
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			StartCoroutine ("DeathAnim");
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Rigidbody2D rbOther = other.gameObject.GetComponent<Rigidbody2D> ();
		rbOther.bodyType = RigidbodyType2D.Dynamic;
	}

	void OnMouseDown () {
		isDragging = true;
	}

	void OnMouseUp () {
		isDragging = false;
		Vector3 delta = startPosition - transform.position;
		rb.isKinematic = false;
		rb.velocity = delta * elasticity;
	}
}
