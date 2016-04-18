using UnityEngine;
using System.Collections;

public class NPCController_Dave : MonoBehaviour {

	// public DialogController dialogController;
	public float minimumDistance;

	private ModalPanel modalPanel;
	private string[] dialogLines;
	private GameObject player;
	public bool questInProgress;
	public bool questComplete;
	private Movement movementScript;
	private bool clicked;
    public QuestTracker quest;
    public string questType;
    public int questGoal;
    private string item;
    public ItemType questItem;
    public int questID;
    private bool QuestDone;

	// Use this for initialization
	void Start() {
		player = GameObject.FindWithTag("Player");
		movementScript = player.GetComponent<Movement>();
		questInProgress = false;
		questComplete = false;
        switch (questItem)
        {
            case ItemType.VINE:
                item = "Vine";
                break;
            case ItemType.STONE:
                item = "Stone";
                break;
            case ItemType.FIRE:
                item = "Fire";
                break;
            case ItemType.WOOD:
                item = "Wood";
                break;
            case ItemType.BOTTLE:
                item = "Bottle";
                break;

        }
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
        if(quest.ActiveQuest && quest.QuestComplete && quest.questID == questID)
        {
            quest.ActiveQuest = false;
            questComplete = true;
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

        if (QuestDone)
        {
            modalPanel.Choice("Thanks for helping me out!");
        }
        else if (quest.questID == 0 || quest.questID == questID) 
        {
			if (questType == "Collect Quest") {
				//questComplete = true;
				this.GetComponent<QuestReward> ().collectQuest ();
			}
            if (!questComplete && !questInProgress)
            {
                if (questType == "Kill Quest")
                {
                    modalPanel.Choice("These monsters have been causing so much trouble! Can you get rid of " + questGoal + " monsters?", AcceptQuest, DeclineQuest);
                }
                else
                {
                    modalPanel.Choice("There has been a lot of danger around here lately I haven't been able to collect any " + item + "s. Could you help me collect " + questGoal + " " + item + "s?", AcceptQuest, DeclineQuest);
                }
                //modalPanel.Choice("Would you like to start this quest?", AcceptQuest, DeclineQuest);
            }
            else if (!questComplete && questInProgress)
            {
                if (questType == "Kill Quest")
                {
                    modalPanel.Choice("Have you killed " + questGoal + " monsters yet? Oh... well come back when you finish.");
                }
                else
                {
                    modalPanel.Choice("Have you collected " + questGoal + " " + item + "s yet? Oh... well come back when you finish.");
                }
                    
            }
            else if (questComplete)
            {
                if (questType == "Kill Quest")
                {
                    modalPanel.Choice("Thanks for killing those monsters!");

                    questInProgress = false;
                    questComplete = false;
                    QuestDone = true;
                    quest.QuestComplete = questComplete;
                    quest.questID = 0;
                    quest.count = 0;

					/*Item newBoot = gameObject.AddComponent<Item> ();
					newBoot.type = ItemType.BOOT;
					newBoot.spriteNeutral = bootNeutral;
					newBoot.spriteHighlighted = bootHighlight;
					newBoot.maxSize = 99;
					newBoot.itemName = "Pair of Boots";
					newBoot.description = "Well you can't go barefoot, right?";
					newBoot.defense = 5f;
					newBoot.hp = 5f;
					newBoot.quality = Quality.COMMON;
					//this.GetComponent<QuestReward> ().giveReward (newBoot);
					QuestReward Areward = this.GetComponent<QuestReward>();
					Areward.giveReward (newBoot);*/
                }
                else
                {
                    modalPanel.Choice("Thanks for all the " + item + "s! I can finally get back to work!");
                    questInProgress = false;
                    questComplete = false;
                    QuestDone = true;
                    quest.QuestComplete = questComplete;
                    quest.questID = 0;
                    quest.count = 0;
                }

                player.GetComponent<Reputation>().addRep(50);
            }
        }
        else
        {
            modalPanel.Choice("It looks like you're helping someone else at the moment. Come back when you're free.");
        }
	}

	void AcceptQuest() {
		questInProgress = true;
        quest.type = questType;
        quest.goal = questGoal;
        quest.ActiveQuest = questInProgress;
        quest.QuestComplete = questComplete;
        quest.questID = questID;
        if (questType == "Collect Quest")
        {
            quest.targetItem = questItem;
        }

        modalPanel.Choice("Thanks for the help!");
	}

	void DeclineQuest() {
		modalPanel.Choice("Come back if you change your mind!");
	}
}
