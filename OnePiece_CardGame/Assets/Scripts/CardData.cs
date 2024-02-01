using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Card", fileName = "New Card Data")]
public class CardData : ScriptableObject
{

    [SerializeField] private static int staticDisplayID = 0;

    [SerializeField] private int displayID;
    [SerializeField] private string cardID;
    [SerializeField] private string cardName;
    [SerializeField] private int counter;
    [SerializeField] private string types;
    [SerializeField] private string imageID;
    [SerializeField] private string trigger;
    [SerializeField] private int life;
    [SerializeField] private string colors;
    [SerializeField] private string cardSet;
    [SerializeField] private string effect;
    [SerializeField] private string imageURL;
    [SerializeField] private string attribute;
    [SerializeField] private int power;

    [SerializeField] private bool onPlay;
    [SerializeField] private bool blocker;
    [SerializeField] private bool main;
    [SerializeField] private bool donX1;
    [SerializeField] private bool donX2;
    [SerializeField] private bool rush;
    [SerializeField] private bool counterEffect;
    [SerializeField] private bool activateMain;
    [SerializeField] private bool whenAttacking;
    [SerializeField] private bool onKO;
    [SerializeField] private bool banish;
    [SerializeField] private bool yourTurn;
    [SerializeField] private bool endOfYourTurn;
    [SerializeField] private bool onYourOppAttack;
    [SerializeField] private bool opponentsTurn;
    [SerializeField] private bool oncePerTurn;
    [SerializeField] private bool restDON;
    [SerializeField] private bool donXX;
    [SerializeField] private bool doubleAttack;
    [SerializeField] private bool isTrigger;
    [SerializeField] private bool isLeader;
    [SerializeField] private bool isCharacter;
    [SerializeField] private bool isEvent;
    [SerializeField] private bool isStage;
    [SerializeField] private bool isDon;

    [SerializeField] private Sprite spriteImage;

    public int DisplayID { get => displayID; set => displayID = value; }
    public string CardID { get => cardID; set => cardID = value; }
    public string CardName { get => cardName; set => cardName = value; }
    public int Counter { get => counter; set => counter = value; }
    public string Types { get => types; set => types = value; }
    public string ImageID { get => imageID; set => imageID = value; }
    public string Trigger { get => trigger; set => trigger = value; }
    public int Life { get => life; set => life = value; }
    public string Colors { get => colors; set => colors = value; }
    public string CardSet { get => cardSet; set => cardSet = value; }
    public string Effect { get => effect; set => effect = value; }
    public string ImageURL { get => imageURL; set => imageURL = value; }
    public string Attribute { get => attribute; set => attribute = value; }
    public int Power { get => power; set => power = value; }
    public bool OnPlay { get => onPlay; set => onPlay = value; }
    public bool Blocker { get => blocker; set => blocker = value; }
    public bool Main { get => main; set => main = value; }
    public bool DonX1 { get => donX1; set => donX1 = value; }
    public bool DonX2 { get => donX2; set => donX2 = value; }
    public bool Rush { get => rush; set => rush = value; }
    public bool CounterEffect { get => counterEffect; set => counterEffect = value; }
    public bool ActivateMain { get => activateMain; set => activateMain = value; }
    public bool WhenAttacking { get => whenAttacking; set => whenAttacking = value; }
    public bool OnKO { get => onKO; set => onKO = value; }
    public bool Banish { get => banish; set => banish = value; }
    public bool YourTurn { get => yourTurn; set => yourTurn = value; }
    public bool EndOfYourTurn { get => endOfYourTurn; set => endOfYourTurn = value; }
    public bool OnYourOppAttack { get => onYourOppAttack; set => onYourOppAttack = value; }
    public bool OpponentsTurn { get => opponentsTurn; set => opponentsTurn = value; }
    public bool OncePerTurn { get => oncePerTurn; set => oncePerTurn = value; }
    public bool RestDON { get => restDON; set => restDON = value; }
    public bool DonXX { get => donXX; set => donXX = value; }
    public bool DoubleAttack { get => doubleAttack; set => doubleAttack = value; }
    public bool IsTrigger { get => isTrigger; set => isTrigger = value; }
    public bool IsLeader { get => isLeader; set => isLeader = value; }
    public bool IsCharacter { get => isCharacter; set => isCharacter = value; }
    public bool IsEvent { get => isEvent; set => isEvent = value; }
    public bool IsStage { get => isStage; set => isStage = value; }
    public bool IsDon { get => isDon; set => isDon = value; }
    public Sprite SpriteImage { get => spriteImage; set => spriteImage = value; }

    public static CardData ValueOf(Card card)
    {
        CardData cardData = CreateInstance<CardData>();
        //CardData cardData = new CardData();
        cardData.DisplayID = ++staticDisplayID;
        cardData.CardID = card.CardID;
        cardData.CardName = card.CardName;
        cardData.Counter = card.Counter;
        cardData.Types = card.Types;
        cardData.ImageID = card.ImageID;
        cardData.Trigger = card.Trigger;
        cardData.Life = card.Life;
        cardData.Colors = card.Colors;
        cardData.CardSet = card.CardSet;
        cardData.Effect = card.Effect;
        cardData.ImageURL = card.ImageURL;
        cardData.Attribute = card.Attribute;
        cardData.Power = card.Power;
        cardData.SpriteImage = card.SpriteImage;
        cardData.OnPlay = card.OnPlay;
        cardData.Blocker = card.Blocker;
        cardData.Main = card.Main;
        cardData.DonX1 = card.DonX1;
        cardData.DonX2 = card.DonX2;
        cardData.Rush = card.Rush;
        cardData.CounterEffect = card.CounterEffect;
        cardData.ActivateMain = card.ActivateMain;
        cardData.WhenAttacking = card.WhenAttacking;
        cardData.OnKO = card.OnKO;
        cardData.Banish = card.Banish;
        cardData.YourTurn = card.YourTurn;
        cardData.EndOfYourTurn = card.EndOfYourTurn;
        cardData.OnYourOppAttack = card.OnYourOppAttack;
        cardData.OpponentsTurn = card.OpponentsTurn;
        cardData.OncePerTurn = card.OncePerTurn;
        cardData.RestDON = card.RestDON;
        cardData.DonXX = card.DonXX;
        cardData.DoubleAttack = card.DoubleAttack;
        cardData.IsTrigger = card.IsTrigger;
        cardData.IsLeader = card.IsLeader;
        cardData.IsCharacter = card.IsCharacter;
        cardData.IsEvent = card.IsEvent;
        cardData.IsStage = card.IsStage;
        cardData.IsDon = card.IsDon;

        //SaveSriptableObject(cardData);

        return cardData;
    }

    public override bool Equals(object obj)
    {
        return obj is CardData data &&
               base.Equals(obj) &&
               cardID == data.cardID;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(base.GetHashCode());
        hash.Add(name);
        hash.Add(hideFlags);
        hash.Add(displayID);
        hash.Add(cardID);
        hash.Add(cardName);
        hash.Add(counter);
        hash.Add(types);
        hash.Add(imageID);
        hash.Add(trigger);
        hash.Add(life);
        hash.Add(colors);
        hash.Add(cardSet);
        hash.Add(effect);
        hash.Add(imageURL);
        hash.Add(attribute);
        hash.Add(power);
        hash.Add(onPlay);
        hash.Add(blocker);
        hash.Add(main);
        hash.Add(donX1);
        hash.Add(donX2);
        hash.Add(rush);
        hash.Add(counterEffect);
        hash.Add(activateMain);
        hash.Add(whenAttacking);
        hash.Add(onKO);
        hash.Add(banish);
        hash.Add(yourTurn);
        hash.Add(endOfYourTurn);
        hash.Add(onYourOppAttack);
        hash.Add(opponentsTurn);
        hash.Add(oncePerTurn);
        hash.Add(restDON);
        hash.Add(donXX);
        hash.Add(doubleAttack);
        hash.Add(isTrigger);
        hash.Add(isLeader);
        hash.Add(isCharacter);
        hash.Add(isEvent);
        hash.Add(isStage);
        hash.Add(isDon);
        hash.Add(spriteImage);
        hash.Add(DisplayID);
        hash.Add(CardID);
        hash.Add(CardName);
        hash.Add(Counter);
        hash.Add(Types);
        hash.Add(ImageID);
        hash.Add(Trigger);
        hash.Add(Life);
        hash.Add(Colors);
        hash.Add(CardSet);
        hash.Add(Effect);
        hash.Add(ImageURL);
        hash.Add(Attribute);
        hash.Add(Power);
        hash.Add(OnPlay);
        hash.Add(Blocker);
        hash.Add(Main);
        hash.Add(DonX1);
        hash.Add(DonX2);
        hash.Add(Rush);
        hash.Add(CounterEffect);
        hash.Add(ActivateMain);
        hash.Add(WhenAttacking);
        hash.Add(OnKO);
        hash.Add(Banish);
        hash.Add(YourTurn);
        hash.Add(EndOfYourTurn);
        hash.Add(OnYourOppAttack);
        hash.Add(OpponentsTurn);
        hash.Add(OncePerTurn);
        hash.Add(RestDON);
        hash.Add(DonXX);
        hash.Add(DoubleAttack);
        hash.Add(IsTrigger);
        hash.Add(IsLeader);
        hash.Add(IsCharacter);
        hash.Add(IsEvent);
        hash.Add(IsStage);
        hash.Add(IsDon);
        hash.Add(SpriteImage);
        return hash.ToHashCode();
    }

    /*public static void SaveSriptableObject(CardData cardData)
    {

        AssetDatabase.CreateAsset(cardData, "Assets/ScriptableObjects/" + cardData.CardID + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = cardData;
    }*/
}
