using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public GameObject dialogueObject;
	private Queue<Sentence> sentences;
	private bool _typing;
	private string _lastSentece;
	private int currentType;
	
	void Start () {
		sentences = new Queue<Sentence>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		currentType = dialogue.type;
        dialogueObject.SetActive(true);
        
		sentences.Clear();

		foreach (Sentence sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void StartDialogueDelayed(Dialogue dialogue)
	{
		StartCoroutine(DelayedStartDialogue(dialogue));
	}

	private IEnumerator DelayedStartDialogue(Dialogue dialogue)
	{
		yield return new WaitForSeconds(1);
		StartDialogue(dialogue);
	}

	public void DisplayNextSentence ()
	{
		if (_typing)
		{
			EndSentence(_lastSentece);
			return;
		}

		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}


		Sentence sentence = sentences.Dequeue();
		nameText.text = sentence.name;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence.text));
		_lastSentece = sentence.text;
	}

	IEnumerator TypeSentence (string sentence)
	{
		_typing = true;
		dialogueText.text = "";
		string currentText = "";
		
		for (int i = 0; i < sentence.Length; i++)
		{
			currentText = sentence.Substring(0,i) + "<color=#00000000>" + sentence.Substring(i) + "</color>";
			dialogueText.text = currentText;
			yield return new WaitForSeconds(0.005f);
		}
		EndSentence(sentence);
	}

	private void EndSentence(string sentence)
	{
		StopAllCoroutines();
		_typing = false;
		dialogueText.text = sentence;
	}

	void EndDialogue()
	{
        dialogueObject.SetActive(false);
		if (currentType == 1)
		{
			FindObjectOfType<GameManager>().EndClient();
			StartCoroutine(FindObjectOfType<GameManager>().StartDelayed(2));
		}
	}

}