using UnityEngine;
using System.Collections;

public class gameoverscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void mainmenu() {
		Application.LoadLevel ("Main Menu");
	}

	public void Quit(){
		Application.Quit ();
	}


}
