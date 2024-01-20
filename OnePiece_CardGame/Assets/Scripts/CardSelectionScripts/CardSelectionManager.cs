using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    public List<CardDisplay> displays = new List<CardDisplay> ();

    public JSONReader jsonReader;
    public CardDatabaseBehaviour cardDatabase;

    
    void Awake()
    {
        jsonReader.ReadAndImportData();
        //cardDisplay.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
