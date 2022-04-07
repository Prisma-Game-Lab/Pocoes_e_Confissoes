using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<GameManager>().mouseOverUI = true;
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectOfType<GameManager>().mouseOverUI = false;
    }

    private void OnDisable()
    {
        if (FindObjectOfType<GameManager>())
        {
            FindObjectOfType<GameManager>().mouseOverUI = false;
        }
    }
}
