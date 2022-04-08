using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ResetTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter.Invoke();
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit.Invoke();
    }

    private void OnDisable()
    {
        OnExit.Invoke();
    }
}
