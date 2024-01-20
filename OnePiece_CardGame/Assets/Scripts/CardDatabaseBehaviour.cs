using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabaseBehaviour : MonoBehaviour
{
    /*public List<Card> cards = new List<Card>();

    void Awake()
    {
        
    }

    public void AddCardToList(Card card)
    {
        card.SpriteImage = Resources.Load<Sprite>("Images/Cards/" + card.CardID);
        cards.Add(card);
    }*/

    //-------------------------------------

    public static List<CardData> cards = new List<CardData>();

    void Awake()
    {

    }

    public void AddCardToList(CardData card)
    {
        card.SpriteImage = Resources.Load<Sprite>("Images/Cards/" + card.CardID);
        cards.Add(card);
    }

    public static int DatabaseSize()
    {
        return cards.Count;
    }
}
