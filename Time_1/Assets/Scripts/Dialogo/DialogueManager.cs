using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public GameObject dialogueObject;
	private Queue<string> sentences;
	private bool _typing;
	private string _lastSentece;

	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
        dialogueObject.SetActive(true);
        
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
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

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		_lastSentece = sentence;
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
	}

}