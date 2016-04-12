using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	//Variables
	public Button returnIcon;
	
	public void toPause(){
		//Time.timeScale = 0f;
		returnIcon.gameObject.SetActive (true);
	}

	public void unPause(){
		//Time.timeScale = 1f;
		returnIcon.gameObject.SetActive(false);
	}
}
