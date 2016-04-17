using UnityEngine;
using System.Collections;

public class QuestTracker : MonoBehaviour
{

    public int count;
    public int goal;
    public string type;
    public bool ActiveQuest;
    public bool QuestComplete;
    public ItemType targetItem;
    public int questID;
    void Start()
    {
        count = 0;
        goal = 0;
        type = "";
        ActiveQuest = false;
        QuestComplete = false;
        targetItem = ItemType.VINE;
        questID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveQuest && !QuestComplete && count >= goal)
        {
            QuestComplete = true;
        }
    }
}