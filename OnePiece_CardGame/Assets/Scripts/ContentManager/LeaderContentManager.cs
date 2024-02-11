using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderContentManager : MonoBehaviour
{
    [SerializeField] private Text leaderHeaderText;

    private Button leaderButton;
    private GameObject cardInDropPanelCopy;
    private CardData cardData;

    private int leaderCount = 0;

    public void Instantiate(GameObject cardInDropPanel, GameObject parent, CardData cardData, GameObject cardInSelectionPanel)
    { 
        InitCardData(cardData);

        if (ContentContainsLeader())
        {
            DropCardInDropPanel(cardInDropPanel, parent, cardData, cardInSelectionPanel);
        }
        else
        {
            RemoveCardFromContent();
            DropCardInDropPanel(cardInDropPanel, parent, cardData, cardInSelectionPanel);
        }
    }

    /**
     * Getter / Setter
     */

    public CardData CardData { get => cardData; set => cardData = value; }

    /**
     * private helper methods 
     */

    private bool ContentContainsLeader()
    {
        return gameObject.transform.childCount == 0;
    }

    private void DropCardInDropPanel(GameObject cardInDropPanel, GameObject parent, CardData cardData, GameObject cardInSelectionPanel)
    {
        cardInDropPanelCopy = Instantiate(cardInDropPanel, transform.position, transform.rotation);
        cardInDropPanelCopy.transform.SetParent(parent.transform);
        cardInDropPanelCopy.transform.localScale = Vector2.one;
        cardInDropPanelCopy.transform.GetChild(0).GetComponent<Text>().text = cardData.CardName;
        cardInDropPanelCopy.transform.GetChild(1).GetComponent<Text>().text = 1.ToString();
        cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardData = cardData;
        cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardInSelectionPanel = cardInSelectionPanel;
        SetColorCircle(cardData);
        InitLeaderButton();
        leaderCount = 1;
        SetLeaderHeaderText();
        UpdateDotsInCardInSelectionPanel(cardInDropPanelCopy);
    }

    private void InitCardData(CardData cardData)
    {
        this.cardData = cardData;
    }

    private void InitLeaderButton()
    {
        leaderButton = cardInDropPanelCopy.transform.GetComponent<Button>();
        leaderButton.onClick.AddListener(RemoveCardFromContent);
    }

    private void SetLeaderHeaderText()
    {
        leaderHeaderText.text = "Leader (" + leaderCount + "/1)";
    }

    private void SetColorCircle(CardData cardData)
    {
        GameObject colorCircle = cardInDropPanelCopy.transform.GetChild(3).gameObject;
        GameObject leftHalf = colorCircle.transform.GetChild(0).gameObject;
        GameObject rigthHalf = colorCircle.transform.GetChild(1).gameObject;

        Image leftHalfImage = leftHalf.GetComponent<Image>();
        Image rightHalfImage = rigthHalf.GetComponent<Image>();

         if (cardData.HasMultipleColors())
         {
            leftHalfImage.color = cardData.GetFirstColor();
            rightHalfImage.color = cardData.GetSecondColor();
         }
         else
         {
             leftHalfImage.color = cardData.GetColor(cardData.Colors);
             rightHalfImage.color = leftHalfImage.color;
         }
    }

    private void RemoveCardFromContent()
    {

        Destroy(cardInDropPanelCopy);
        leaderCount = 0;
        SetLeaderHeaderText();
        UpdateDotsInCardInSelectionPanel(cardInDropPanelCopy);
    }

    public void UpdateDotsInCardInSelectionPanel(GameObject cardInDropPanelCopy)
    {
        GameObject cardInSelectionPanel = cardInDropPanelCopy.GetComponent<DisplayCardInDropPanel>().CardInSelectionPanel;
        GameObject dotPanel = cardInSelectionPanel.transform.GetChild(0).gameObject;

        if (leaderCount == 0)
        {
            ResetDots(cardInSelectionPanel, dotPanel);
        }
        else
        {
            GameObject dot = dotPanel.transform.GetChild(2).gameObject;
            GameObject dotChild = dot.transform.GetChild(0).gameObject;
            dotChild.GetComponent<Image>().color = Color.white;
        }
    }

    private void ResetDots(GameObject cardInSelectionPanel, GameObject dotPanel)
    {
        GameObject dot = dotPanel.transform.GetChild(2).gameObject;
        GameObject dotChild = dot.transform.GetChild(0).gameObject;
        dotChild.GetComponent<Image>().color = new Color32(132, 132, 132, 255);
    }
}
