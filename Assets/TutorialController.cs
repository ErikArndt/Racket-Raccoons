using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GameObject t;

	void Start () {
		t.SetActive (false);
	}

	public void OnPointerEnter (PointerEventData eventData) {
		Debug.Log ("Hovered");
		t.SetActive (true);
	}

	public void OnPointerExit (PointerEventData eventData) {
		Debug.Log ("Unhovered");
		t.SetActive (false);
	}
}
