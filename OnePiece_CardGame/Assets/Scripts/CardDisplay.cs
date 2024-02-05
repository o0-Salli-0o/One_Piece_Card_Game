using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CardDisplay : MonoBehaviour
{

    public int displayID;

    public CardData card;
    public Image cardImage;

    private int databaseSize;

    static int i = 0;

    public void Init()
    {
        //databaseSize = CardSelectionPanelScript.databaseSize;
        //databaseSize = CardToPanelTest.databaseSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Clone")
        {
            Debug.Log("b: " + i++);
            //card = CardSelectionPanelScript.staticDatabaseList[databaseSize - 1];
            card = CardToPanelTest.cards[databaseSize - 1];
            databaseSize -= 1;
            //CardSelectionPanelScript.databaseSize -= 1;
            //CardToPanelTest.databaseSize -= 1;
            this.tag = "Untagged";
        }

        cardImage.sprite = card.SpriteImage;
    }
}
