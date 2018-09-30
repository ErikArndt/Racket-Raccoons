using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour, IPointerDownHandler {

	public void OnPointerDown (PointerEventData eventData) {
		Debug.Log ("Clicked");
		SceneManager.LoadScene ("SampleScene");
	}
}
