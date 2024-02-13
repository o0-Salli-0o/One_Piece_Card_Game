using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PageToPanelTest : MonoBehaviour
{
    private static int CARDS_PER_PAGE = 10;

    public ContentManager contentManager;
    public GameObject cardSelectionPagePrefab;

    // Start is called before the first frame update
    void Start()
    {
        PagesToSelectionPanel(CardDatabaseBehaviour.cards);
    }

    public void PagesToSelectionPanel(List<CardData> cards)
    {
        for(int i = 0; i <= PageCount(cards); i++)
        {
            PageToSelectionPanel();
        }
    }

    private int PageCount(List<CardData> cards)
    {
        int cardCount = 0;
        int pageCount = 0;

        for (int i = 0; i < cards.Count; i++)
        {
            cardCount++;

            if(cardCount == CARDS_PER_PAGE)
            {
                if(i < cards.Count - 1)
                {
                    pageCount++;
                }
                cardCount = 0;
            }
        }
        return pageCount;
    }

    private void PageToSelectionPanel()
    {
        GameObject cardSelectionPageCopy = Instantiate(cardSelectionPagePrefab, transform.position, transform.rotation);
        cardSelectionPageCopy.transform.SetParent(this.transform);
        cardSelectionPageCopy.SetActive(true);
        cardSelectionPageCopy.transform.localScale = Vector2.one;
        cardSelectionPageCopy.transform.position = new Vector2(transform.position.x, transform.position.y);
        cardSelectionPageCopy.transform.eulerAngles = new Vector2(25, 0);
        contentManager.contentPanels.Add(cardSelectionPageCopy);
    }
}
