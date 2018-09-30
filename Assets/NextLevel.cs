using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	private Button thisBtn;

	// Use this for initialization
	void Start () {
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(LoadNext);
	}
	
	void LoadNext () {
        PlayerController.GoalReached = false;
		SceneManager.LoadScene ("level2");
	}
}
