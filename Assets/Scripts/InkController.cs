using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkController : MonoBehaviour {
	[SerializeField]
	private TextAsset inkJSONAsset;
	private Story story;

	[SerializeField]
	private GameObject[] Buttons;

	// UI Prefabs
	[SerializeField]
	private Text textPrefab;

	[SerializeField]
	private Button buttonContinue;

	void Awake () {
		StartStory();
	}

	void StartStory () {
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}

	void RefreshView () {
		RemoveChildren ();
		string text = story.Continue ().Trim();
		CreateContentView(text);
		if(story.canContinue){
			Button continueB = buttonContinue;
			continueB.gameObject.SetActive(true);
			continueB.onClick.RemoveAllListeners();
			continueB.onClick.AddListener(delegate{
			RefreshView();
			});
		}else{
			Button choice = buttonContinue;
			choice.gameObject.SetActive(true);
			choice.onClick.RemoveAllListeners();
			choice.onClick.AddListener(delegate{
			Choice();
			});
		}
	}

	void Choice(){
		RemoveChildren();
		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = Buttons[i].GetComponent<Button>();
				button.GetComponentInChildren<Text> ().text = choice.text.Trim ();
				button.gameObject.SetActive(true);
				button.onClick.RemoveAllListeners();
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		} else {
			Button choice = buttonContinue;
			choice.gameObject.SetActive(true);
			choice.onClick.RemoveAllListeners();
			choice.onClick.AddListener(delegate{
				StartStory();
			});
		}
	}

	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	void CreateContentView (string text) {
		textPrefab.text = text;
		textPrefab.gameObject.SetActive(true);
	}

	/*Button CreateChoiceView (string text) {
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (this.transform, false);

		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}*/

	void RemoveChildren () {
		int childCount = this.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			this.transform.GetChild (i).gameObject.SetActive(false);
		}
	}
}
