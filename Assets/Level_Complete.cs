using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Complete : MonoBehaviour {
    public GameObject display;
   


	// Use this for initialization
	void Start () {
        display.gameObject.SetActive(false);

	}

  
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKey(KeyCode.R)){
            PlayerController.GoalReached = false;
            display.gameObject.SetActive(false);
        }
        if (PlayerController.GoalReached == true)
        {
            display.gameObject.SetActive(true);
        }

    }
}
