using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardToContent : MonoBehaviour/*, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler*/
{
    [SerializeField] private GameObject cardInDropPanel;
    private GameObject leaderPanelContent;
    private GameObject playerPanelContent;

    public void AddCardToContent()
    {
        leaderPanelContent = GameObject.Find("LeaderContent");
        playerPanelContent = GameObject.Find("PlayerContent");

        if (GetComponent<CardDisplayTest>().CardData.IsLeader)
        {
            leaderPanelContent.GetComponent<LeaderContentManager>().Instantiate(cardInDropPanel, leaderPanelContent, GetComponent<CardDisplayTest>().CardData, this.gameObject);
        }
        else
        {
            playerPanelContent.GetComponent<PlayerContentManager>().Instantiate(cardInDropPanel, playerPanelContent, GetComponent<CardDisplayTest>().CardData, this.gameObject);
        }
    }
}
