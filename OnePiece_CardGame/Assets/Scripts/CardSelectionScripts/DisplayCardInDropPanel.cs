using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCardInDropPanel : MonoBehaviour
{
    private CardData cardData;

    [SerializeField] private Text cardCounterText;

    public CardData CardData { get => cardData; set => cardData = value; }

}
