using UnityEngine;
using System.Collections;

public class QuestReward : MonoBehaviour {

    public QuestTracker quest;
    private bool ActiveQuest;
    private bool QuestComplete;
    private string type;
    private bool dead;
    public GameObject me;
    public Inventory inv;
    public ItemType item;
    void Start () {
        type = "";
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        ActiveQuest = quest.ActiveQuest;
        QuestComplete = quest.QuestComplete;
        type = quest.type;
        item = quest.targetItem;
        if (this.transform.CompareTag("Enemy"))
        {
            killQuest();
        }
        else
        {
            collectQuest();
        }
    }
    void killQuest()
    {
        if(type == "Kill Quest")
        {
            if (ActiveQuest && !QuestComplete)
            {
                if (!me.activeSelf && !dead)
                {
                    dead = true;
                    quest.count = quest.count + 1;
                }
            }
        }
    }
    void collectQuest()
    {
        if(type == "Collect Quest")
        {
            if(ActiveQuest && !QuestComplete)
            {
                inv.collectQuestCheck();
            }
        }
    }
}
