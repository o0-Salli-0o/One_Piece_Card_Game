using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayTest : MonoBehaviour
{
    private CardData cardData;
    [SerializeField] private Image cardImage;

    public CardData CardData { get => cardData; set => cardData = value; }
    public Image CardImage { get => cardImage; set => cardImage = value; }

    public void InitCardDisplay(CardData cardData)
    {
        this.cardData = cardData;
        cardImage.sprite = cardData.SpriteImage;
    }
}
