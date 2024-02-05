using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPanelTest : MonoBehaviour
{
    private static readonly int CARDS_PER_PAGE = 10;

    public GameObject pagePrefab;
    public GameObject cardPrefab;

    public static List<CardData> cards = new();

    private readonly List<CardData> cardsOfPage = new();

    private static int curCardIndex;

    // Start is called before the first frame update
    void Start()
    {
        CardsToPanel();
    }

    private void CardsToPanel()
    {
        cards = CardDatabaseBehaviour.cards;

        for (int i = 0; i < CARDS_PER_PAGE; i++)
        {
            // in case the last page contains only 9 or less cards
            if (curCardIndex >= cards.Count) break;

            CardToPanel();
            cardsOfPage.Add(cards[curCardIndex]);
            curCardIndex++;
        }
    }

    private void CardToPanel()
    {
        GameObject cardInSelectionPanelCopy;
        cardInSelectionPanelCopy = Instantiate(cardPrefab, transform.position, transform.rotation);
        cardInSelectionPanelCopy.transform.SetParent(pagePrefab.transform);
        cardInSelectionPanelCopy.GetComponent<CardDisplayTest>().InitCardDisplay(cards[curCardIndex]);
        cardInSelectionPanelCopy.transform.localScale = Vector2.one;

        if (cardInSelectionPanelCopy.GetComponent<CardDisplayTest>().CardData.IsLeader)
        {
            HideDots(cardInSelectionPanelCopy);
        }
    }

    private void HideDots(GameObject cardInSelectionPanelCopy)
    {
        GameObject dotPanel = cardInSelectionPanelCopy.transform.GetChild(0).gameObject;
        GameObject dot0 = dotPanel.transform.GetChild(0).gameObject;
        GameObject dot1 = dotPanel.transform.GetChild(1).gameObject;
        GameObject dot3 = dotPanel.transform.GetChild(3).gameObject;

        dot0.SetActive(false);
        dot1.SetActive(false);
        dot3.SetActive(false);
    }
}
