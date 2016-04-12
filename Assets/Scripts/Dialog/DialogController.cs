using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class DialogController : MonoBehaviour {

	public Sprite icon;
	public Transform spawnPoint;
	public GameObject thingToSpawn;

	private ModalPanel modalPanel;
	private DisplayManager displayManager;

	// private UnityAction myYesAction;
	// private UnityAction myNoAction;
	// private UnityAction myCancelAction;

	void Awake() {
		modalPanel = ModalPanel.Instance();
		displayManager = DisplayManager.Instance();

		// myYesAction = new UnityAction(TestYesFunction);
		// myNoAction = new UnityAction(TestNoFunction);
		// myCancelAction = new UnityAction(TestCancelFunction);
	}

	// Send to the ModalPanel to set up the Buttons and Functions to call

	public void TestOK() {
		modalPanel.Choice("This is the default text for an OK dialog box.", TestOKFunction);
	}

	public void TestOK(string text) {
		modalPanel.Choice(text, TestOKFunction);
	}

	public void TestYN() {
		modalPanel.Choice("This is the default text for a Yes/No dialog box.", TestYesFunction, TestNoFunction);
	}

	public void TestYN(string text) {
		modalPanel.Choice(text, TestYesFunction, TestNoFunction);
	}

	public void TestYNC() {
		modalPanel.Choice("This is the default text for a Yes/No/Cancel dialog box.", TestYesFunction, TestNoFunction, TestCancelFunction);
	}

	public void TestYNCI() {
		modalPanel.Choice("This is the default text for a Yes/No/Cancel dialog box with an image.", icon, TestYesFunction, TestNoFunction, TestCancelFunction);
	}

	public void TestLambda() {
		modalPanel.Choice("This is the default text for a Yes/No dialog box that spawns one object.", () => { InstantiateObject(thingToSpawn); }, TestNoFunction);
	}

	public void TestLambda2() {
		modalPanel.Choice("This is the default text for a Yes/No dialog box that spawns two objects.", () => { InstantiateObject(thingToSpawn, thingToSpawn); }, TestNoFunction);
	}

	// These are wrapped into UnityActions
	void TestOKFunction() {
		displayManager.DisplayMessage("OK");
	}

	void TestYesFunction() {
		displayManager.DisplayMessage("Yuuup");
	}

	void TestNoFunction() {
		displayManager.DisplayMessage("Noooo");
	}

	void TestCancelFunction() {
		displayManager.DisplayMessage("What?");
	}

	void InstantiateObject(GameObject thingToInstantiate) {
		displayManager.DisplayMessage("Here you go!");
		Instantiate(thingToInstantiate, spawnPoint.position, spawnPoint.rotation);
	}

	void InstantiateObject(GameObject thingToInstantiate, GameObject thingToInstantiate2) {
		displayManager.DisplayMessage("Here you go!");
		Instantiate(thingToInstantiate, spawnPoint.position - new Vector3(1, 1, 0), spawnPoint.rotation);
		Instantiate(thingToInstantiate2, spawnPoint.position + new Vector3(1, 1, 0), spawnPoint.rotation);
	}

}
