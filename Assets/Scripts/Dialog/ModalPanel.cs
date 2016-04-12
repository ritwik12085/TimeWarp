using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModalPanel : MonoBehaviour {

	public Text dialog;
	public Image iconImage;
	public Button okButton;
	public Button yesButton;
	public Button noButton;
	public Button cancelButton;
	public GameObject modalPanelObject;

	private static ModalPanel modalPanel;

	public static ModalPanel Instance() {
		if (!modalPanel) {
			modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
			if (!modalPanel)
				Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
		}
		return modalPanel;
	}

	public bool isActive() {
		return modalPanelObject.activeSelf;
	}

	void ClosePanel() {
		modalPanelObject.SetActive(false);
	}

	// For every set of possible button combinations, write a new Choice() override with the appropriate UnityAction arguments

	public void Choice(string dialog) {
		modalPanelObject.SetActive(true);

		okButton.onClick.RemoveAllListeners();
		okButton.onClick.AddListener(ClosePanel);

		this.dialog.text = dialog;

		this.iconImage.gameObject.SetActive(false);
		okButton.gameObject.SetActive(true);
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);
		cancelButton.gameObject.SetActive(false);
	}

	// Announcement: a string and an OK event
	public void Choice(string dialog, UnityAction okEvent) {
		modalPanelObject.SetActive(true);

		okButton.onClick.RemoveAllListeners();
		okButton.onClick.AddListener(okEvent);
		okButton.onClick.AddListener(ClosePanel);

		this.dialog.text = dialog;

		this.iconImage.gameObject.SetActive(false);
		okButton.gameObject.SetActive(true);
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);
		cancelButton.gameObject.SetActive(false);
	}

	// Yes/No: a string, a Yes event, and a No event
	public void Choice(string dialog, UnityAction yesEvent, UnityAction noEvent) {
		modalPanelObject.SetActive(true);

		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(yesEvent);
		// yesButton.onClick.AddListener(ClosePanel);

		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(noEvent);
		// noButton.onClick.AddListener(ClosePanel);

		this.dialog.text = dialog;

		this.iconImage.gameObject.SetActive(false);
		okButton.gameObject.SetActive(false);
		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
		cancelButton.gameObject.SetActive(false);
	}

	// Yes/No/Cancel: a string, a Yes event, a No event, and a Cancel event
	public void Choice(string dialog, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent) {
		modalPanelObject.SetActive(true);

		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(yesEvent);
		yesButton.onClick.AddListener(ClosePanel);

		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(noEvent);
		noButton.onClick.AddListener(ClosePanel);

		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener(cancelEvent);
		cancelButton.onClick.AddListener(ClosePanel);

		this.dialog.text = dialog;

		this.iconImage.gameObject.SetActive(false);
		okButton.gameObject.SetActive(false);
		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
		cancelButton.gameObject.SetActive(true);
	}

	// Yes/No/Cancel with Image: a string, a Yes event, a No event, and a Cancel event
	public void Choice(string dialog, Sprite iconImage, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent) {
		modalPanelObject.SetActive(true);

		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(yesEvent);
		yesButton.onClick.AddListener(ClosePanel);

		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(noEvent);
		noButton.onClick.AddListener(ClosePanel);

		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener(cancelEvent);
		cancelButton.onClick.AddListener(ClosePanel);

		this.dialog.text = dialog;
		this.iconImage.sprite = iconImage;

		this.iconImage.gameObject.SetActive(true);
		okButton.gameObject.SetActive(false);
		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
		cancelButton.gameObject.SetActive(true);
	}

}