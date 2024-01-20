using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public CardDatabaseBehaviour cardDatabase;
    public JSONReader jsonReader;
    public DisplayCard displayCard;
    public PlayerDeck playerDeck;
    public CardBack cardBack;
    public CardToHand cardToHand;

    // Start is called before the first frame update
    void Start()
    {
        jsonReader.ReadAndImportData();
        displayCard.Init();
        playerDeck.Init();

    }

    // Update is called once per frame
    void Update()
    {
        displayCard.SetStaticCardBack();
        cardBack.CheckCardBack();
        playerDeck.UpdateDeckVisualization();
        cardToHand.Init();
        //displayCard.MakeDrawCardVisible();
        displayCard.DrawCardFromDeck();
    }
}
