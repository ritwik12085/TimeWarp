using UnityEngine;
using System.Collections;

public class NPCController_Dave : MonoBehaviour {

	// public DialogController dialogController;
	public float minimumDistance;

	private ModalPanel modalPanel;
	private string[] dialogLines;
	private GameObject player;
	private bool questInProgress;
	private bool questComplete;
	private Movement movementScript;
	private bool clicked;

	// Use this for initialization
	void Start() {
		player = GameObject.FindWithTag("Player");
		movementScript = GetComponent<Movement>();
		questInProgress = false;
		questComplete = false;
	}

	void Awake() {
		modalPanel = ModalPanel.Instance();
	}

	void Update() {
		if (clicked) {
			if (((Vector2)player.transform.position - (Vector2)this.transform.position).sqrMagnitude < minimumDistance) {
				movementScript.SetTarget(player.transform.position);
				if (!questComplete && !questInProgress) {
					// dialogController.TestYN("Would you like to start this quest?");
					modalPanel.Choice("Would you like to start this quest?", AcceptQuest, DeclineQuest);
				} else if (!questComplete && questInProgress) {
					// dialogController.TestOK("Your quest is in progress!");
					// modalPanel.Choice("Good luck on the quest!");
					modalPanel.Choice("Is the quest complete? I trust your judgment...", CompleteQuest, IncompleteQuest);
				} else if (questComplete) {
					// dialogController.TestOK("Thanks for completing my quest!");
					modalPanel.Choice("Thanks for the help!");
				}
				clicked = false;
			} else {
				movementScript.SetTarget(this.transform.position);
			}
		}
	}

	void OnMouseDown() {
		if (!modalPanel.isActive()) { // only allow dialog if there is not already a dialog box open
			clicked = true;
		}
	}

	void AcceptQuest() {
		questInProgress = true;

		// do stuff, like, add quest description to global tracker

		modalPanel.Choice("Thanks for accepting my quest!");
	}

	void DeclineQuest() {
		modalPanel.Choice("Aww, maybe next time?");
	}

	void CompleteQuest() {
		questInProgress = false;
		questComplete = true;

		// do stuff, like, remove quest description from global tracker, add items to player inventory

		modalPanel.Choice("Wow! Thanks so much!");
	}

	void IncompleteQuest() {
		modalPanel.Choice("Okay, let me know!");
	}

}
