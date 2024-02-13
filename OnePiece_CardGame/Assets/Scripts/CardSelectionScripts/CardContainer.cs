using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    List<string> colors;
    private const string ALL_CARDS = "All";
    private const string RED_CARDS = "Red";
    private const string GREEN_CARDS = "Green";
    private const string BLUE_CARDS = "Blue";
    private const string PURPLE_CARDS = "Purple";
    private const string BLACK_CARDS = "Black";
    private const string YELLOW_CARDS = "Yellow";

    List<string> types;
    private const string LEADER_CARDS = "Leader";
    private const string CHARACTER_CARDS = "Character";
    private const string STAGE_CARDS = "Stage";
    private const string EVENT_CARDS = "Event";

    public GameObject cardPrefab;

    private readonly static List<CardData> staticCardsList = new();
    private static List<GameObject> cardObjects = new();

    // Start is called before the first frame update
    void Start()
    {
        colors = new List<string>() { RED_CARDS, GREEN_CARDS, BLUE_CARDS, PURPLE_CARDS, BLACK_CARDS, YELLOW_CARDS };
        types = new List<string>() { LEADER_CARDS, CHARACTER_CARDS, STAGE_CARDS, EVENT_CARDS };

        FillContainer();

    }

    public void Add(GameObject cardInSelectionPanel)
    {
        if (!ContainerContains(cardInSelectionPanel))
        {
            cardInSelectionPanel.transform.SetParent(this.transform);
            cardInSelectionPanel.SetActive(false);
            AddCardToContainer(cardInSelectionPanel);
        }
    }

    public void RemoveTo(GameObject cardInSelectionPanel, GameObject parent)
    {
        cardInSelectionPanel.transform.SetParent(parent.transform);
        cardInSelectionPanel.SetActive(true);
        cardInSelectionPanel.transform.localScale = Vector2.one;
        RemoveCardFromContainer(cardInSelectionPanel);
    }

    public List<GameObject> GetCardsBy(string filterCriteria)
    {
        List<GameObject> cards = new();

        if (filterCriteria.Equals(ALL_CARDS))
        {
            cards = GetAllCards();
        }
        else
        {
            if (colors.Contains(filterCriteria))
                cards = FilterCardsByColor(filterCriteria);
            else
                cards = FilterCardsByType(filterCriteria);
        }
        return cards;
    }

    public void Sort()
    {
        cardObjects = cardObjects.OrderBy(x => x.GetComponent<CardDisplayTest>().CardData.DisplayID).ToList();
    }

    private List<GameObject> GetAllCards()
    {
        return cardObjects;
    }

    private List<GameObject> FilterCardsByColor(string filterCriteria)
    {
        List<GameObject> resultList = new();

        foreach (GameObject card in cardObjects)
        {
            CardData cardData = card.GetComponent<CardDisplayTest>().CardData;

            if (cardData.Colors.Contains(filterCriteria))
            {
                resultList.Add(card);
            }
        }
        return resultList;
    }

    private List<GameObject> FilterCardsByType(string filterCriteria)
    {
        switch (filterCriteria)
        {
            case LEADER_CARDS:
                return GetLeaderCards();

            case CHARACTER_CARDS:
                return GetCharacterCards();

            case EVENT_CARDS:
                return GetEventCards();

            case STAGE_CARDS:
                return GetStageCards();

            default:
                return GetAllCards();
        }
    }

    private List<GameObject> GetLeaderCards()
    {
        List<GameObject> resultList = new();

        foreach (GameObject card in cardObjects)
        {
            CardData cardData = card.GetComponent<CardDisplayTest>().CardData;

            if (cardData.IsLeader)
            {
                resultList.Add(card);
            }
        }
        return resultList;
    }

    private List<GameObject> GetCharacterCards()
    {
        List<GameObject> resultList = new();

        foreach (GameObject card in cardObjects)
        {
            CardData cardData = card.GetComponent<CardDisplayTest>().CardData;

            if (cardData.IsCharacter)
            {
                resultList.Add(card);
            }
        }
        return resultList;
    }

    private List<GameObject> GetEventCards()
    {
        List<GameObject> resultList = new();

        foreach (GameObject card in cardObjects)
        {
            CardData cardData = card.GetComponent<CardDisplayTest>().CardData;

            if (cardData.IsEvent)
            {
                resultList.Add(card);
            }
        }
        return resultList;
    }

    private List<GameObject> GetStageCards()
    {
        List<GameObject> resultList = new();

        foreach (GameObject card in cardObjects)
        {
            CardData cardData = card.GetComponent<CardDisplayTest>().CardData;

            if (cardData.IsStage)
            {
                resultList.Add(card);
            }
        }
        return resultList;
    }

    private void AddCardToContainer(GameObject cardInSelectionPanel)
    {
        CardData cardData = cardInSelectionPanel.GetComponent<CardDisplayTest>().CardData;

        if (!staticCardsList.Contains(cardData))
        {
            staticCardsList.Add(cardData);
            cardObjects.Add(cardInSelectionPanel);
        }
    }

    private void RemoveCardFromContainer(GameObject cardInSelectionPanel)
    {
        CardData cardData = cardInSelectionPanel.GetComponent<CardDisplayTest>().CardData;

        if (staticCardsList.Contains(cardData))
        {
            staticCardsList.Remove(cardData);

            foreach(GameObject card in cardObjects.ToList())
            {

                if(card.GetComponent<CardDisplayTest>().CardData.Equals(cardData))
                {
                    cardObjects.Remove(card);
                }
            }
        }
    }

    private void FillContainer()
    {
        int index = 0;

        List<CardData> cards = CardDatabaseBehaviour.cards;

        for (int i = 0; i < cards.Count; i++)
        {
            GameObject cardInSelectionPanelCopy = Instantiate(cardPrefab, transform.position, transform.rotation);
            cardInSelectionPanelCopy.transform.SetParent(this.gameObject.transform);
            cardInSelectionPanelCopy.SetActive(false);
            cardInSelectionPanelCopy.GetComponent<CardDisplayTest>().InitCardDisplay(cards[index++]);
            AddCardToContainer(cardInSelectionPanelCopy);
            HideDotsForLeaderCards(cardInSelectionPanelCopy);
        }
    }

    private void HideDotsForLeaderCards(GameObject cardInSelectionPanelCopy)
    {
        if (cardInSelectionPanelCopy.GetComponent<CardDisplayTest>().CardData.IsLeader)
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

    private bool ContainerContains(GameObject cardInSelectionPage)
    {
        CardData cardData = cardInSelectionPage.GetComponent<CardDisplayTest>().CardData;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (cardData.Equals(this.transform.GetChild(i).gameObject.GetComponent<CardDisplayTest>().CardData))
            {
                return true;
            }
        }
        return false;
    }
}
