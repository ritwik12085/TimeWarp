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
    public QuestTracker quest;
    public string questType;
    public int questGoal;
    public string item;

	// Use this for initialization
	void Start() {
		player = GameObject.FindWithTag("Player");
		movementScript = player.GetComponent<Movement>();
		questInProgress = false;
		questComplete = false;
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
        if(quest.ActiveQuest && quest.QuestComplete)
        {
            quest.ActiveQuest = false;
            questComplete = quest.QuestComplete;
        }
	}

	void OnMouseDown() {
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
		if (!questComplete && !questInProgress) {
            if(questType == "Kill Quest")
            {
                modalPanel.Choice("These monsters have been causing so much trouble! Can you get rid of " + questGoal + " monster?", AcceptQuest, DeclineQuest);
            }
            else
            {
                modalPanel.Choice("There has been a lot of danger around here lately I haven't been able to collect any " + item + "s. Could you help me collect " + questGoal + item + "s>", AcceptQuest, DeclineQuest);
            }
			//modalPanel.Choice("Would you like to start this quest?", AcceptQuest, DeclineQuest);
		} else if (!questComplete && questInProgress) {
			modalPanel.Choice("Have you finished my task? Oh... okay come back when its finished.");
		} else if (questComplete) {
            if (questType == "Kill Quest")
            {
                modalPanel.Choice("Thanks for killing those monsters!");

                questInProgress = false;
                questComplete = false;
                quest.QuestComplete = questComplete;


                modalPanel.Choice("Allow me to show my appreciation. Take this.");
            }
            else
            {
                modalPanel.Choice(" Thanks for all the " + item + "s! I can finally get back to work!");
                questInProgress = false;
                questComplete = false;
                quest.QuestComplete = questComplete;


                modalPanel.Choice("Allow me to show my appreciation. Take this.");
            }
        }
	}

	void AcceptQuest() {
		questInProgress = true;
        quest.type = questType;
        quest.goal = questGoal;
        quest.ActiveQuest = questInProgress;
        quest.QuestComplete = false;
        if (questType == "Collect Quest")
        {
            quest.targetItem = item;
        }

        modalPanel.Choice("Thanks for the help!");
	}

	void DeclineQuest() {
		modalPanel.Choice("Come back if you change your mind!");
	}
}
