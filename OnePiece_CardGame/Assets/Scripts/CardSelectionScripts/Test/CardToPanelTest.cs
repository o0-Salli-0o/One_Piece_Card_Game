using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPanelTest : MonoBehaviour
{

    //public ContentManager contentManager;

    public GameObject parent;
    public GameObject cardPrefab;
    //public GameObject pagePrefab;

    public static List<CardData> cards = new List<CardData>();
    public static List<CardData> leaderCards = new List<CardData> ();

    public static int databaseSize;
    public static int leaderCardsSize;

    // Start is called before the first frame update
    void Start()
    {
        //int counter = 0;

        CardDatabaseBehaviour.cards.Reverse();
        cards = CardDatabaseBehaviour.cards;
        databaseSize = cards.Count;

        for(int i = 0; i < cards.Count; i++)
        {
            if (cards[i].IsLeader)
            {
                //counter++;
                leaderCards.Add(cards[i]);
                /*if(counter == 13)
                {
                    contentManager.contentPanels.Add(Instantiate(pagePrefab, transform.position, transform.rotation));
                    counter = 0;
                }*/

                GameObject cardSelectionPage = Instantiate(cardPrefab, transform.position, transform.rotation);
                cardSelectionPage.transform.SetParent(parent.transform);
                //contentManager = cardSelectionPage.GetComponent<ContentManager>();
                //contentManager.contentPanels.Add(cardSelectionPage);
            }
        }
        leaderCardsSize = leaderCards.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
