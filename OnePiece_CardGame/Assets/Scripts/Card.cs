using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Card
{

    public string cardID;
    public string cardName;
    public int counter;
    public string types;
    public string imageID;
    public string trigger;
    public int life;
    public string colors;
    public string cardSet;
    public string effect;
    public string imageURL;
    public string attribute;
    public int power;

    public bool onPlay;
    public bool blocker;
    public bool main;
    public bool donX1;
    public bool donX2;
    public bool rush;
    public bool counterEffect;
    public bool activateMain;
    public bool whenAttacking;
    public bool onKO;
    public bool banish;
    public bool yourTurn;
    public bool endOfYourTurn;
    public bool onYourOppAttack;
    public bool opponentsTurn;
    public bool oncePerTurn;
    public bool restDON;
    public bool donXX;
    public bool doubleAttack;
    public bool isTrigger;
    public bool isLeader;
    public bool isCharacter;
    public bool isEvent;
    public bool isStage;
    public bool isDon;

    public Sprite spriteImage;


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
    public Sprite SpriteImage { get => spriteImage; set => spriteImage = value; }
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
}
