using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    //[HideInInspector] public DragableItem dragableItem;

    [SerializeField] private GameObject cardInDropPanel;

    private GameObject cardInSelectionPanel;
    private CardData currCardData;

    [SerializeField] private GameObject leaderPanelContent;
    [SerializeField] private GameObject playerPanelContent;

    public void OnDrop(PointerEventData eventData)
    {
        Init(eventData);
        AddCardToContent();




        //dragableItem = dropped.GetComponent<DragableItem>();
        //Debug.Log(dragableItem.GetComponent<CardDisplayTest>().cardData.CardName);

        /*GameObject dropped = eventData.pointerDrag;
        DragableItem dragableItem = dropped.GetComponent<DragableItem>();
        dragableItem.parentAfterDrag = transform;*/
        
    }

    private void Init(PointerEventData eventData)
    {
        cardInSelectionPanel = eventData.pointerDrag;
        currCardData = cardInSelectionPanel.GetComponent<CardDisplayTest>().cardData;
        Debug.Log(currCardData.CardName);
    }

    private void AddCardToContent()
    {
        if (currCardData.IsLeader)
        {
            //if (leaderPanelContent.transform.childCount == 0)
            //{
                //Instantiate(cardInDropPanel, transform.position, transform.rotation);
                leaderPanelContent.GetComponent<LeaderContentManager>().Instantiate(cardInDropPanel, leaderPanelContent, currCardData);
            //}
        }
        else
        {
            playerPanelContent.GetComponent<PlayerContentManager>().Instantiate(cardInDropPanel, playerPanelContent, currCardData);
        }
    }
}
