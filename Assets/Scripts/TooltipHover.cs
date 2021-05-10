using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    [SerializeField] private Tooltip tooltip;
   

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!tooltip.gameObject.activeInHierarchy)
        {
            Tooltip.ShowTooltip_Static(text);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltip.gameObject.activeInHierarchy)
        {
            Tooltip.HideTooltip_Static();
        }
    }
}
