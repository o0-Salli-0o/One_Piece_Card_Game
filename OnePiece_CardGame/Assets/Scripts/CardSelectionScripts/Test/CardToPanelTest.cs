using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardToPanelTest : MonoBehaviour
{
    private static readonly int CARDS_PER_PAGE = 10;

    public GameObject pagePrefab;
    public GameObject cardPrefab;

    //public static List<CardData> cards = new();

    private static int curCardIndex;

    public void CardsToPanel(List<CardData> cards)
    {
        GameObject cardContainer = GameObject.Find("CardContainer");
        List<GameObject> cardsPerPage = new();

        for (int i = 0; i < cards.Count; i++)
        {
            GameObject cardInSelectionPage = GetCardFromContainer(cards[i], cardContainer);
            cardsPerPage.Add(cardInSelectionPage);
        }

        foreach (GameObject card in cardsPerPage)
        {

            CardToPanel(card, cardContainer);
        }
    }

    private GameObject GetCardFromContainer(CardData cardData, GameObject cardContainer)
    {
        GameObject cardInSelectionPage = null;

        for (int i = 0; i < cardContainer.transform.childCount; i++)
        {
            GameObject child = cardContainer.transform.GetChild(i).gameObject;

            if (child.GetComponent<CardDisplayTest>().CardData.Equals(cardData))
            {
                cardInSelectionPage = child;
            }
        }
        return cardInSelectionPage;
    }

    public void CardsToPanel()
    {
        GameObject cardContainer = GameObject.Find("CardContainer");
        List<GameObject> cardsPerPage = new();

        for (int i = 0; i < CARDS_PER_PAGE; i++)
        {
            if (curCardIndex >= CardDatabaseBehaviour.cards.Count)
            {
                ResetCurCardIndex();
                break;
            }

            GameObject cardInSelectionPage = cardContainer.transform.GetChild(i).gameObject;
            cardsPerPage.Add(cardInSelectionPage);
            curCardIndex++;
        }

        foreach (GameObject card in cardsPerPage)
        {

            CardToPanel(card, cardContainer);
        }
    }

    private void CardToPanel(GameObject card, GameObject cardContainer)
    {
        cardContainer.GetComponent<CardContainer>().RemoveTo(card, pagePrefab);
    }

    private static void ResetCurCardIndex()
    {
        curCardIndex = 0;
    }
}
