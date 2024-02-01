using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    //public Canvas canvas;

    //private RectTransform rectTransform;

    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
        //canvas = GetComponent<Canvas>()
        
    }

    /*private void Update()
    {
        if (canvas == null)
        {
            canvas = this.GetComponentInParent<Canvas>();
            Debug.Log("a");
        }
    }*/

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        //this.gameObject.GetComponent<LayoutElement>().ignoreLayout = true;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        //Debug.Log(gameObject.GetComponent<CardDisplayTest>().cardData.CardName);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //rectTransform.anchoredPosition = eventData.delta /*/ canvas.scaleFactor*/;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
