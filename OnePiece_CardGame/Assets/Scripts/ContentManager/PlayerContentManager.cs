using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerContentManager : MonoBehaviour
{
    [SerializeField] private Text playerHeaderText;

    private Button playerButton;

    private List<CardData> cards = new List<CardData>();

    public void Instantiate(GameObject cardInDropPanel, GameObject parent, CardData currCardData, GameObject cardInSelectionPanel)
    {
        if (cards.Contains(currCardData))
        {
            // max 4 same cards per deck
            if (IsAvailable(currCardData))
            {
                UpdateCardInDropPanel(currCardData);
                //AddToCards(currCardData);
            }
        }
        else
        {
            DropCardInDropPanel(cardInDropPanel, parent, currCardData, cardInSelectionPanel);
            //AddToCards(currCardData);
        }
        SetPlayerHeaderText();
    }

    /**
     * getter / setter
     */

    public List<CardData> Cards { get => cards; set => cards = value; }

    /**
     * private helper methods 
     */

    private void DropCardInDropPanel(GameObject cardInDropPanel, GameObject parent, CardData cardData, GameObject cardInSelectionPanel)
    {
        GameObject cardInDropPanelCopy;
        cardInDropPanelCopy = InstantiateCopyOf(cardInDropPanel, parent);
        Text nameText = cardInDropPanelCopy.transform.GetChild(0).GetComponent<Text>();
        nameText.text = cardData.CardName;
        cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardData = cardData;
        cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardInSelectionPanel = cardInSelectionPanel;
        Text cardCounterText = cardInDropPanelCopy.transform.GetChild(1).GetComponent<Text>();
        cardCounterText.text = 1.ToString();
        SetColorCircle(cardInDropPanelCopy, cardData);
        InitPlayerButton(cardInDropPanelCopy);
        AddToCards(cardData);
        UpdateDotsInCardInSelectionPanel(cardInDropPanelCopy);
    }

    private GameObject InstantiateCopyOf(GameObject cardInDropPanel, GameObject parent)
    {
        GameObject cardInDropPanelCopy = Instantiate(cardInDropPanel, transform.position, transform.rotation);
        cardInDropPanelCopy.transform.SetParent(parent.transform);
        cardInDropPanelCopy.transform.localScale = Vector2.one;
        return cardInDropPanelCopy;
    }

    private void SetColorCircle(GameObject cardInDropPanelCopy, CardData cardData)
    {
        GameObject colorCircle = cardInDropPanelCopy.transform.GetChild(3).gameObject;
        GameObject leftHalf = colorCircle.transform.GetChild(0).gameObject;
        GameObject rigthHalf = colorCircle.transform.GetChild(1).gameObject;

        Image leftHalfImage = leftHalf.GetComponent<Image>();
        Image rightHalfImage = rigthHalf.GetComponent<Image>();

        leftHalfImage.color = cardData.GetColor(cardData.Colors);
        rightHalfImage.color = leftHalfImage.color;
    }

    private void AddToCards(CardData cardData)
    {
        cards.Add(cardData);
    }

    private bool IsAvailable(CardData cardData)
    {
        if(CurrCardCount(cardData) < 4) { return true; }
        return false;
    }

    private int CurrCardCount(CardData currCardData)
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
        foreach(Transform cardInDropPanelTransform in transform)
        {
            if (cardInDropPanelTransform.GetComponent<DisplayCardInDropPanel>().CardData.CardID == currCardData.CardID)
            {
                Text cardCounterText = cardInDropPanelTransform.GetChild(1).GetComponent<Text>();
                cardCounterText.text = (CurrCardCount(currCardData) + 1).ToString();
                AddToCards(currCardData);
                UpdateDotsInCardInSelectionPanel(cardInDropPanelTransform.gameObject);
            }
        }
    }

    private void SetPlayerHeaderText()
    {
        playerHeaderText.text = "Deck (" + cards.Count + "/50)";
    }

    private void InitPlayerButton(GameObject cardInDropPanelCopy)
    {
        playerButton = cardInDropPanelCopy.transform.GetComponent<Button>();
        playerButton.onClick.AddListener(RemoveCardFromContent);
    } 

    private void RemoveCardFromContent()
    {
        GameObject removableCardInDropPanelCopy = EventSystem.current.currentSelectedGameObject;
        CardData removableCardData = removableCardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardData;

        for(int i = 0; i < cards.Count; i++)
        {
            CardData card = cards[i];

            if (card.CardID == removableCardData.CardID)
            {
                if (CurrCardCount(card) > 1)
                {
                    removableCardInDropPanelCopy.transform.GetChild(1).GetComponent<Text>().text = (CurrCardCount(card) - 1).ToString();
                    cards.Remove(card);
                }
                else
                {
                    Destroy(removableCardInDropPanelCopy);
                    cards.Remove(card);
                }
                UpdateDotsInCardInSelectionPanel(removableCardInDropPanelCopy);
                SetPlayerHeaderText();
                break;
            }
        }
    }

    private void UpdateDotsInCardInSelectionPanel(GameObject cardInDropPanelCopy)
    {
        CardData cardData = cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardData;
        GameObject cardInSelectionPanel = cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardInSelectionPanel;
        GameObject dotPanel = cardInSelectionPanel.transform.GetChild(0).gameObject;
        int nrOfCardsInDeck = CurrCardCount(cardData);

        ResetDots(cardInSelectionPanel, dotPanel);

        for (int i = 0; i < nrOfCardsInDeck; i++)
        {
            GameObject dot = dotPanel.transform.GetChild(i).gameObject;
            GameObject dotChild = dot.transform.GetChild(0).gameObject;
            dotChild.GetComponent<Image>().color = Color.white;
        }
    }

    private void ResetDots(GameObject cardInSelectionPanel, GameObject dotPanel)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject dot = dotPanel.transform.GetChild(i).gameObject;
            GameObject dotChild = dot.transform.GetChild(0).gameObject;
            dotChild.GetComponent<Image>().color = new Color32(132, 132, 132, 255);
        }
    }
}
