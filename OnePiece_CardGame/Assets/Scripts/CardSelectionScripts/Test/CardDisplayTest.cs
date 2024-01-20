using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayTest : MonoBehaviour
{
    public CardData cardData;
    public Image cardImage;

    // Start is called before the first frame update
    void Start()
    {
        cardData = CardToPanelTest.leaderCards[CardToPanelTest.leaderCardsSize - 1];
        cardImage.sprite = cardData.SpriteImage;
        //CardToPanelTest.databaseSize -= 1;
        CardToPanelTest.leaderCardsSize -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
