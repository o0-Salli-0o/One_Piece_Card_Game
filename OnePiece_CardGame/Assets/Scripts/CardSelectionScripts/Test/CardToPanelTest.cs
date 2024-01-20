using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPanelTest : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelCard;

    public static List<CardData> cards = new List<CardData>();
    public static List<CardData> leaderCards = new List<CardData> ();

    public static int databaseSize;
    public static int leaderCardsSize;

    // Start is called before the first frame update
    void Start()
    {
        CardDatabaseBehaviour.cards.Reverse();
        cards = CardDatabaseBehaviour.cards;
        databaseSize = cards.Count;

        for(int i = 0; i < cards.Count; i++)
        {
            if (cards[i].IsLeader)
            {
                leaderCards.Add(cards[i]);
                Instantiate(panelCard, transform.position, transform.rotation);
            }
        }
        leaderCardsSize = leaderCards.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
