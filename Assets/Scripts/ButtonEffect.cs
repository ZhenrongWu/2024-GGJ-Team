using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private RectTransform rectTransform;
    private TextMeshProUGUI text;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        text.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        text.color = Color.white;
    }
}
