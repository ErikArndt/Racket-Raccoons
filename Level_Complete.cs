using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Complete : MonoBehaviour {
    public GameObject display;
    private bool GoalReached = false;


	// Use this for initialization
	void Start () {
        display.gameObject.SetActive(false);

	}

    void ToggleVisibility(){
        if (GoalReached == true)
        {
            display.gameObject.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            GoalReached = true;
            ToggleVisibility();
        }
	}
}
