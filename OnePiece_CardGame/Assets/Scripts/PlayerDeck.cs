using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public CardDatabaseBehaviour cardDatabase;
    public int x;
    public int deckSize;
    public List<Card> playerDeck = new List<Card>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject cardToHand;
    public GameObject[] clones;
    public GameObject hand;

    public void Init()
    {

        x = 0;

        for(int i = 0; i < deckSize; i++)
        {
            /*x = Random.Range(0, cardDatabase.cards.Count);
            //playerDeck[i] = cardDatabase.cards[x];
            playerDeck.Add(cardDatabase.cards[x]);*/
        }

        //cardInDeck1 = GameObject.Find("DeckCard");

        StartCoroutine(StartGame());

    }

    public void UpdateDeckVisualization()
    {
        RemoveCardFromDeck();
        AddCardToDeck();
    }

    private IEnumerator StartGame()
    {
        for(int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(1);

            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }


    private void RemoveCardFromDeck()
    {
        if (deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }

        if (deckSize < 20)
        {
            cardInDeck2.SetActive(false);
        }

        if (deckSize < 10)
        {
            cardInDeck3.SetActive(false);
        }

        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }
    }

    private void AddCardToDeck()
    {
        if (!cardInDeck1.activeSelf && deckSize >= 30)
        {
            cardInDeck1.SetActive(true);
        }

        if (!cardInDeck2.activeSelf && deckSize >= 20)
        {
            cardInDeck2.SetActive(true);
        }

        if (!cardInDeck3.activeSelf && deckSize >= 10)
        {
            cardInDeck3.SetActive(true);
        }

        if (!cardInDeck4.activeSelf && deckSize >= 1)
        {
            cardInDeck4.SetActive(true);
        }
    }
}
