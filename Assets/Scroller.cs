using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {
	public float scrollSpeed, heightWorld;
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
	}

	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, heightWorld);
		transform.position = startPosition + Vector3.down * newPosition;
	}
}
