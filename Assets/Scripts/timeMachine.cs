using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class timeMachine : MonoBehaviour {

    public GameObject player;
	public Inventory inventory;
	public Text endLevelText;
	public Canvas endLevel1Canvas;
   
    public Canvas startLevel1Canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        bool isLevelDone = false;
        bool isLevel2Done = false;
        bool isLevel3Done = false;
        if (Application.loadedLevelName == "MasterScene2")
        {
            isLevel2Done = inventory.endLevel2Check();
        }
        else if(Application.loadedLevelName == "MasterScene")
        {
            isLevelDone = inventory.endLevel1Check();
        }else if (Application.loadedLevelName == "MasterScene3")
        {
            isLevel3Done = inventory.endLevel3Check();
        }
		Debug.Log (isLevelDone);
		if (isLevelDone) {
			endLevel1Canvas.GetComponent<CanvasGroup> ().alpha = 1;
			endLevel1Canvas.GetComponent<CanvasGroup> ().interactable = true;
			endLevel1Canvas.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
        if(isLevel2Done) {
            endLevel1Canvas.GetComponent<CanvasGroup>().alpha = 1;
            endLevel1Canvas.GetComponent<CanvasGroup>().interactable = true;
            endLevel1Canvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        if (isLevel3Done)
        {
            endLevel1Canvas.GetComponent<CanvasGroup>().alpha = 1;
            endLevel1Canvas.GetComponent<CanvasGroup>().interactable = true;
            endLevel1Canvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

	public void toggleStartCanvas(){
		startLevel1Canvas.GetComponent<CanvasGroup> ().alpha = 0;
		startLevel1Canvas.GetComponent<CanvasGroup> ().interactable = false;
		startLevel1Canvas.GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

    public void goToLevel2(){
        if (player.GetComponent<Reputation>().getRepStatus() == 1)
        {
            Application.LoadLevel("MasterScene2");
        }
        else { Application.LoadLevel("MasterScene3"); }
   }

    public void toMainMenu()
    {

        Application.LoadLevel("Main Menu");
    }
}
