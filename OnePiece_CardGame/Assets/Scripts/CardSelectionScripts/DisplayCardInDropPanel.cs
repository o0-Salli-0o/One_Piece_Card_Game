using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCardInDropPanel : MonoBehaviour
{
    private CardData cardData;
    private GameObject cardInSelectionPanel;

    [SerializeField] private Text cardCounterText;

    public CardData CardData { get => cardData; set => cardData = value; }
    public GameObject CardInSelectionPanel { get => cardInSelectionPanel; set => cardInSelectionPanel = value; }

}
