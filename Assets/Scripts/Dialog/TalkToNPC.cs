using UnityEngine;
using System.Collections;

public class TalkToNPC : MonoBehaviour {

	public DialogController dialogController;
	public TextAsset textFile;
	public float minimumDistance;

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

	void OnMouseDown() {
		if (((Vector2)player.transform.position - (Vector2)this.transform.position).sqrMagnitude < minimumDistance) {
			dialogController.TestOK(dialogLines[Random.Range(0, dialogLines.Length)]);
		}
	}

}
