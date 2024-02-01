using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContentManager : MonoBehaviour
{
    private List<CardData> cards = new List<CardData>();
    //private List<GameObject, CardData> cardsWithGameObject = new List<GameObject, CardData>();

    public void Instantiate(GameObject cardInDropPanel, GameObject parent, CardData currCardData)
    {
        //InitCardData(cardData);

        if (cards.Contains(currCardData))
        {
            if (IsAvailable(currCardData))
            {
                UpdateCardInDropPanel(currCardData);
                AddToCards(currCardData);
            }
        }
        else
        {
            DropCardInDropPanel(cardInDropPanel, parent, currCardData);
            AddToCards(currCardData);
        }
    }

    /**
     * private helper methods 
     */

    private void DropCardInDropPanel(GameObject cardInDropPanel, GameObject parent, CardData cardData)
    {
        GameObject cardInDropPanelCopy = Instantiate(cardInDropPanel, transform.position, transform.rotation);
        cardInDropPanelCopy.transform.SetParent(parent.transform);
        cardInDropPanelCopy.transform.GetChild(0).GetComponent<Text>().text = cardData.CardName;
        cardInDropPanelCopy.transform.localScale = Vector2.one;
        cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardData = cardData;
        cardInDropPanelCopy.transform.GetChild(1).GetComponent<Text>().text = 1.ToString();
    }

    private void AddToCards(CardData cardData)
    {
        cards.Add(cardData);
    }

    private bool IsAvailable(CardData cardData)
    {
        /*int counter = 0;

        foreach(CardData card in cards)
        {
            if(card.CardID == cardData.CardID)
            {
                counter++;
            }
        }*/

        if(GetCardCount(cardData) < 4) { return true; }
        return false;
    }

    private int GetCardCount(CardData currCardData)
    {
        int counter = 0;

        foreach (CardData card in cards)
        {
            if (card.CardID == currCardData.CardID)
            {
                counter++;
            }
        }
        return counter;
    }

    private void UpdateCardInDropPanel(CardData currCardData)
    {
        //foreach(GameObject cardInDropPanel in gameObject.transform.get)

        foreach(Transform cardInDropPanel in transform)
        {
            if (cardInDropPanel.GetComponent<DisplayCardInDropPanel>().CardData.CardID == currCardData.CardID)
            {
                cardInDropPanel.GetChild(1).GetComponent<Text>().text = (GetCardCount(currCardData) + 1).ToString();
            }
        }
    }
}
