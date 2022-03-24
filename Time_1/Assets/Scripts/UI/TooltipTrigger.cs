using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string tooltipContent;
    public string tooltipHeader;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Show(tooltipContent, tooltipHeader);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Hide();
    }

    public void OnMouseEnter()
    {
        Tooltip.Show(tooltipContent, tooltipHeader);
    }

    public void OnMouseExit()
    {
        Tooltip.Hide();
    }
}
