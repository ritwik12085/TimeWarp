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
	public float minimumDistance;

	private ModalPanel modalPanel;
	private string[] dialogLines;
	private GameObject player;

	// Use this for initialization
	void Start() {
		// Make sure there this a text file assigned before continuing
		if (textFile != null) {
			// Add each line of the text file to the array using the new line as the delimiter
			dialogLines = (textFile.text.Split('\n'));
		}

		player = GameObject.FindWithTag("Player");
	}

	void Awake() {
		modalPanel = ModalPanel.Instance();
	}

	void OnMouseDown() {

		if (!modalPanel.isActive()) {
			if (((Vector2)player.transform.position - (Vector2)this.transform.position).sqrMagnitude < minimumDistance) {
				modalPanel.Choice(dialogLines[Random.Range(0, dialogLines.Length)]);
			}
		}
	}
}
