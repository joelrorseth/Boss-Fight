using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	void Start () {
		//get the Btton component and add a listener to it
		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (DoOnClick);
	}
	
	void DoOnClick()
	{
		//From Main Menu go to Level 1
		if (gameObject.name == "Level1Button") {
			SceneManager.LoadScene("Level1", LoadSceneMode.Single);
		}
		//From Main Menu go to Level 2
		else if (gameObject.name == "Level2Button") {
			SceneManager.LoadScene("Level2", LoadSceneMode.Single);
		}
		//From Main Menu go to Level 3
		else if (gameObject.name == "Level3Button") {
			SceneManager.LoadScene("Level3", LoadSceneMode.Single);
		}
		//From Main Menu go to Scores
		else if (gameObject.name == "ScoresButton") {
			SceneManager.LoadScene("Scores", LoadSceneMode.Single);
		}
		//From Scores or 1 of the levels return to Main Menu
		else if (gameObject.name == "BackButton") {
			SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
		}
	}
}
