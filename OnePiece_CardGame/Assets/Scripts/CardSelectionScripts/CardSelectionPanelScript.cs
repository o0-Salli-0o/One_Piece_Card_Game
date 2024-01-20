using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardSelectionPanelScript : MonoBehaviour
{

    public static int databaseSize;
    public static List<CardData> staticDatabaseList = new List<CardData>();

    //public GameObject[] clones;
    //public GameObject cardToSelectionPanel;

    public GameObject cardInSelectionPanel;

    static int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        CardDatabaseBehaviour.cards.Reverse();
        databaseSize = CardDatabaseBehaviour.cards.Count;
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        staticDatabaseList = CardDatabaseBehaviour.cards;
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i < CardDatabaseBehaviour.cards.Count; i++)
        {
            yield return null;
            Debug.Log("a: " + a++);
            Instantiate(cardInSelectionPanel, transform.position, transform.rotation);
        }
    }
}
