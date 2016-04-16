using UnityEngine;
using System.Collections;

public class QuestReward : MonoBehaviour {

    public QuestTracker quest;
    private bool ActiveQuest;
    private bool QuestComplete;
    private string type;
    private bool dead;
    public GameObject me;
    void Start () {
        type = "";
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        ActiveQuest = quest.ActiveQuest;
        QuestComplete = quest.QuestComplete;
        type = quest.type;
        if (this.transform.CompareTag("Enemy"))
        {
            killQuest();
        }
        else
        {

        }
    }
    void killQuest()
    {
        if(type == "Kill Quest")
        {
            Debug.Log(2);
            if (ActiveQuest && !QuestComplete)
            {
                Debug.Log(1);
                if (!me.activeSelf && !dead)
                {
                    Debug.Log(0);
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
                Debug.Log("hello");
            }
        }
    }
}
