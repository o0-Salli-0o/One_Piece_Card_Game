using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageToPanelTest : MonoBehaviour
{
    private static int CARDS_PER_PAGE = 10;

    public ContentManager contentManager;
    public GameObject cardSelectionPagePrefab;

    // Start is called before the first frame update
    void Start()
    {
        PagesToSelectionPanel();
    }

    private void PagesToSelectionPanel()
    {
        for(int i = 0; i <= PageCount(); i++)
        {
            PageToSelectionPanel();
        }
    }

    private int PageCount()
    {

        int cardCount = 0;
        int pageCount = 0;

        foreach(CardData card in CardDatabaseBehaviour.cards)
        {
            cardCount++;

            if(cardCount == CARDS_PER_PAGE)
            {
                pageCount++;
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
