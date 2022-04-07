using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Button2d : MonoBehaviour
{
    private void OnMouseDown()
    {        
        if (FindObjectOfType<GameManager>().mouseOverUI)
            return;
        if (FindObjectOfType<DialogueManager>()._talking)
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        else
        FindObjectOfType<GameManager>().PlayClient();
    }

}
