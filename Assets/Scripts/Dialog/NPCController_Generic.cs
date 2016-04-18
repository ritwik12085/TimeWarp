using UnityEngine;
using System.Collections;

/* This script allows programming of a generic NPC
 * who will select a random line to say from a text file.
 * The text file should be themed; for example, there is a
 * Generic_Friendly.txt which contains lines appropriate
 * for NPCs who are friendly with the player character. */

public class NPCController_Generic : MonoBehaviour {

	// public DialogController dialogController;
	public TextAsset textFile;
	private float minimumDistance;

	private ModalPanel modalPanel;
	private string[] dialogLines;
	private GameObject player;
	private Movement movementScript;
	private bool clicked;

	// Use this for initialization
	void Start() {
		minimumDistance = 15;
		// Make sure there this a text file assigned before continuing
		if (textFile != null) {
			// Add each line of the text file to the array using the new line as the delimiter
			dialogLines = textFile.text.Split('\n');
		}

		player = GameObject.FindWithTag("Player");
		movementScript = player.GetComponent<Movement>();
	}

	void Awake() {
		modalPanel = ModalPanel.Instance();
	}

	void Update() {
		if (clicked) {
			if (((Vector2)player.transform.position - (Vector2)this.transform.position).sqrMagnitude < minimumDistance) {
				Talk();
				clicked = false;
			}
		}
	}

	void OnMouseDown() {
		Debug.Log(modalPanel);
		if (!modalPanel.isActive()) { // only allow dialog if there is not already a dialog box open
			if (!(((Vector2)player.transform.position - (Vector2)this.transform.position).sqrMagnitude <= minimumDistance)) {
				movementScript.SetTarget(this.transform.position);
				clicked = true;
			} else {
				Talk();
			}
		}
	}

	void Talk() {
		movementScript.SetTarget(player.transform.position);
		modalPanel.Choice(dialogLines[Random.Range(0, dialogLines.Length)], emptyMethod, KillNPC, 1);
	}

	void emptyMethod(){

	}

	void KillNPC(){
		this.gameObject.SetActive (false);
		player.GetComponent<Reputation> ().subRep (200);
		//Debug.Log (player.GetComponent<Reputation>().reputation);
	}
}
