using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SectorNetwork : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler ,IPointerExitHandler
{
    [SerializeField] private GameObject border;
    [SerializeField] private GameObject target;
    [SerializeField] private bool showing = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (target != null && showing) target.SetActive(true);
        else if (target != null) target.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (border != null) border.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (border != null) border.SetActive(false);
    }
}
