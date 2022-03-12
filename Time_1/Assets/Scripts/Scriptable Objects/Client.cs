using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nome do Cliente", menuName = "Cliente")]

public class Client : ScriptableObject
{
    public List<Order> orders;

    private void OnValidate()
    {
        foreach(Order order in orders)
        {
            foreach(Sentence sentence in order.dialogue.sentences)
            {
                switch (sentence.speaker)
                {
                    case Sentence.Speaker.Cliente:
                        sentence.name = this.name;
                        break;
                    case Sentence.Speaker.Player:
                        sentence.name = "Player";
                        break;
                    default:
                        sentence.name = "ERRO";
                        break;
                }
            }
        }
    }
    public void TriggerDialogue (int i)
	{
		FindObjectOfType<DialogueManager>().StartDialogue(orders[i].dialogue);
	}
}
