using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{

    public CardDatabaseBehaviour cardDatabaseBehaviour;
    public PlayerDeck playerDeck;

    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public string cardID;
    public string cardName;
    /*public int counter;
    public string types;
    public string trigger;
    public int life;
    public string colors;
    public string cardSet;
    public string effect;
    public string attribute;
    public int power;*/
    public Sprite spriteImage;

    public Text nameText;
    /*public Text counterText;
    public Text typesText;
    public Text triggerText;
    public Text lifeText;
    public Text colorsText;
    public Text cardSetText;
    public Text effectText;
    public Text attributeText;
    public Text powerText;*/
    public Image artImage;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject hand;
    public int nrOfCardsInDeck;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init()
    {
        /*Debug.Log("Cards in database: " + cardDatabaseBehaviour.cards.Count);
        displayCard[0] = cardDatabaseBehaviour.cards[displayId];

        cardID = displayCard[0].cardID;
        cardName = displayCard[0].cardName;
        spriteImage = displayCard[0].SpriteImage;

        nameText.text = " " + cardName;
        artImage.sprite = spriteImage;

        nrOfCardsInDeck = playerDeck.deckSize;*/
    }

    public void SetStaticCardBack()
    {
        staticCardBack = cardBack;
    }

    private void MakeDrawCardVisible()
    {
        hand = GameObject.Find("Hand");
        if(this.transform.parent == hand.transform.parent)
        {
            cardBack = false;
        }
    }

    public void DrawCardFromDeck()
    {
        MakeDrawCardVisible();

        if (this.tag == "Clone")
        {
            displayCard[0] = playerDeck.playerDeck[nrOfCardsInDeck - 1];
            nrOfCardsInDeck -= 1;
            playerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }
    }

    // Update is called once per frame
    void Update()
    {

        //cardID = displayCard[0].cardID;
        /*cardName = displayCard[0].cardName;
        counter = displayCard[0].counter;
        types = displayCard[0].types;
        trigger = displayCard[0].trigger;
        life = displayCard[0].life;
        colors = displayCard[0].colors;
        cardSet = displayCard[0].cardSet;
        effect = displayCard[0].effect;
        attribute = displayCard[0].attribute;
        power = displayCard[0].power;*/

        /*nameText.text = " " + cardName;
        counterText.text = " " + counter;
        typesText.text = " " + types;
        triggerText.text = " " + trigger;
        lifeText.text = " " + life;
        colorsText.text = " " + colors;
        cardSetText.text = " " + cardSet;
        effectText.text = " " + effect;
        attributeText.text = " " + attribute;
        powerText.text = " " + power;*/

    }
}
