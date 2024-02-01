using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderContentManager : MonoBehaviour
{
    //private GameObject cardInDropPanel;

    private CardData cardData;

    public void Instantiate(GameObject cardInDropPanel, GameObject parent, CardData cardData)
    { 
        InitCardData(cardData);

        if (gameObject.transform.childCount == 0)
        {
            DropCardInDropPanel(cardInDropPanel, parent, cardData);
        }
        else
        {
            GameObject cardInLeaderContentPanel = gameObject.transform.GetChild(0).gameObject;
            Destroy(cardInLeaderContentPanel);
            DropCardInDropPanel(cardInDropPanel, parent, cardData);
        }
    }

    /**
     * Getter / Setter
     */

    public CardData CardData { get => cardData; set => cardData = value; }

    /**
     * private helper methods 
     */

    private void DropCardInDropPanel(GameObject cardInDropPanel, GameObject parent, CardData cardData)
    {
        //this.cardInDropPanel = cardInDropPanel;
        GameObject cardInDropPanelCopy = Instantiate(cardInDropPanel, transform.position, transform.rotation);
        cardInDropPanelCopy.transform.SetParent(parent.transform);
        cardInDropPanelCopy.transform.GetChild(0).GetComponent<Text>().text = cardData.CardName;
        cardInDropPanelCopy.transform.localScale = Vector2.one;
    }

    private void InitCardData(CardData cardData)
    {
        this.cardData = cardData;
    }
}
