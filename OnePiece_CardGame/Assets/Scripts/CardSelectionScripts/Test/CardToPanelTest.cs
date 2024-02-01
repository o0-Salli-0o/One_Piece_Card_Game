using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPanelTest : MonoBehaviour
{
    //public GameObject cardSelectionPanel;

    public GameObject pagePrefab;
    public GameObject cardPrefab;

    public static List<CardData> cards = new List<CardData>();
    public static List<CardData> leaderCards = new List<CardData> ();
    public static List<CardData> helperList = new List<CardData> ();

    public static int databaseSize;
    public static int leaderCardsSize;

    private static int curCardIndex;

    // Start is called before the first frame update
    void Start()
    {
        CardsToPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CardsToPanel()
    {
        cards = CardDatabaseBehaviour.cards;
        databaseSize = cards.Count;

        int leaderCount = 0;

        while (leaderCount < 10)
        {
            if (curCardIndex >= cards.Count) break;

            //if (cards[curCardIndex].IsLeader)
            //{
                leaderCount++;
                leaderCards.Add(cards[curCardIndex]);

                 CardToPanel();
            //}
            curCardIndex++;
        }
        leaderCardsSize = leaderCards.Count;
    }

    private void CardToPanel()
    {
        GameObject card;
        card = Instantiate(cardPrefab, transform.position, transform.rotation);
        card.transform.SetParent(pagePrefab.transform);
        /*card.transform.localScale = Vector3.one;
        card.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        card.transform.eulerAngles = new Vector3(25, 0, 0);*/
    }
}
