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
        FindObjectOfType<GameManager>().PlayClient();
    }

}
