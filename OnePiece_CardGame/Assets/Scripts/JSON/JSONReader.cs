using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public CardDatabaseBehaviour cardDatabaseBehaviour;

    public void ReadAndImportData()
    {
        CardDatabase cardDatabase = JsonUtility.FromJson<CardDatabase>(jsonFile.text);
        ImportCardsToDatabase(cardDatabase);
    }

    private void ImportCardsToDatabase(CardDatabase cardDatabase)
    {

        //int i = 0;
        foreach (Card card in cardDatabase.cards)
        {
            cardDatabaseBehaviour.AddCardToList(CardData.ValueOf(card));
        }
    }
}
