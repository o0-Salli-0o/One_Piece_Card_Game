using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageToPanelTest : MonoBehaviour
{
    public ContentManager contentManager;
    public GameObject pagePrefab;

    private int pageCount;

    // Start is called before the first frame update
    void Start()
    {
        //pageCount = GetLeadersPageCount();
        InitLeaderPages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitLeaderPages()
    {
        pageCount = GetLeadersPageCount();

        for(int i = 0; i <= pageCount; i++)
        {
            GameObject o = Instantiate(pagePrefab, transform.position, transform.rotation);
            contentManager.contentPanels.Add(o);
        }
    }

    private int GetLeadersPageCount()
    {

        int leaderCount = 0;
        int pageCount = 0;

        foreach(CardData card in CardDatabaseBehaviour.cards)
        {
            //if (card.IsLeader)
            //{
                leaderCount++;
            //}

            if(leaderCount == 10 /*10=cards/page*/)
            {
                pageCount++;
                leaderCount = 0;
            }
        }

        return pageCount;

        //int leadCardCount = GetLeaderCardCount();
        //pageCount = leadCardCount / 10; /* 10 = nr of cards in one page */        
        
    }

    private int GetLeaderCardCount()
    {
        int count = 0;

        foreach (CardData card in CardDatabaseBehaviour.cards)
        {
            if (card.IsLeader)
            {
                count++;
            }
        }
        return count;
    }

    public int PageCount { get => pageCount; set => pageCount = value; }
}
