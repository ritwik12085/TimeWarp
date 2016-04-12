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

	// Use this for initialization
	void Start() {
		player = GameObject.FindWithTag("Player");
		questInProgress = false;
		questComplete = false;
	}

	void Awake() {
		modalPanel = ModalPanel.Instance();
	}

	void OnMouseDown() {
		if (!modalPanel.isActive()) { // only allow dialog if there is not already a dialog box open
			if (((Vector2)player.transform.position - (Vector2)this.transform.position).sqrMagnitude < minimumDistance && !modalPanel.isActive()) {
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
			}
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
