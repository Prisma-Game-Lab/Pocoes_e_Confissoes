using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Button2d : MonoBehaviour
{
    public UnityEvent OnClick;
    private void OnMouseDown()
    {   
        if (FindObjectOfType<GameManager>().mouseOverUI)
            return;
        OnClick.Invoke();
        if (FindObjectOfType<DialogueManager>()._talking)
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        else 
        if (!FindObjectOfType<GameManager>().delivered)
            FindObjectOfType<GameManager>().PlayClient();
    }

}
