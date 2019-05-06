using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, ICharacter
{
    public int PlayerID;
    public CharacterAsset charAsset;
    public PlayerArea PArea;
    public SpellEffect HeroPowerEffect;

    public Deck deck;
    public Hand hand;
    public Table table;

    private int bonusMovementThisTurn = 0;
    public bool usedHeroPowerThisTurn = false;

    public int ID
    {
        get{ return PlayerID; }
    }

    private int movementThisTurn;
    public int MovementThisTurn
    {
        get{ return movementThisTurn;}
        set
        {

            if (value < 0)
                movementThisTurn = 0;
            else if (value > PArea.ManaBar.Crystals.Length)
                movementThisTurn = PArea.ManaBar.Crystals.Length;
            else
            movementThisTurn = value;
           // PArea.ManaBar.TotalCrystals = movementThisTurn;
            new UpdateManaCrystalsCommand(this, movementThisTurn, movementLeft).AddToQueue();
        }
    }

    private int movementLeft;
    public int MovementLeft
    {
        get
        { return movementLeft;}
        set
        {
            if (value < 0)
                movementLeft = 0;
            else if (value > PArea.ManaBar.Crystals.Length)
                movementLeft = PArea.ManaBar.Crystals.Length;
            else
                movementLeft = value;
            //PArea.ManaBar.AvailableCrystals = manaLeft;
            new UpdateManaCrystalsCommand(this, MovementThisTurn, movementLeft).AddToQueue();
            if (TurnManager.Instance.whoseTurn == this)
                HighlightPlayableCards();
        }
    }

    public Player otherPlayer
    {
        get
        {
            if (Players[0] == this)
                return Players[1];
            else
                return Players[0];
        }
    }

    private int health;
    public int Health
    {
        get { return health;}
        set
        {
            health = value;
            if (value <= 0)
                Die(); 
        }
    }

    public delegate void VoidWithNoArguments();
    //public event VoidWithNoArguments CreaturePlayedEvent;
    //public event VoidWithNoArguments SpellPlayedEvent;
    //public event VoidWithNoArguments StartTurnEvent;
    public event VoidWithNoArguments EndTurnEvent;

    public static Player[] Players;

    void Awake()
    {
        Players = GameObject.FindObjectsOfType<Player>();
        PlayerID = IDFactory.GetUniqueID();
    }

    public virtual void OnTurnStart()
    {
        // Agregar movimientos al pool;
        Debug.Log("In ONTURNSTART for "+ gameObject.name);
        usedHeroPowerThisTurn = false;
        MovementThisTurn++;
        MovementLeft = MovementThisTurn;
        foreach (CreatureLogic cl in table.CreaturesOnTable)
            cl.OnTurnStart();
        PArea.HeroPower.WasUsedThisTurn = false;

    }

    public void GetBonusMovement(int amount)
    {
        bonusMovementThisTurn += amount;
        MovementThisTurn += amount;
        MovementLeft += amount;
    }

    public void OnTurnEnd()
    {
        if(EndTurnEvent != null)
            EndTurnEvent.Invoke();
        MovementThisTurn -= bonusMovementThisTurn;
        bonusMovementThisTurn = 0;
        GetComponent<TurnMaker>().StopAllCoroutines();
    }

    // Arrastrar carta del deck
    public void DrawACard(bool fast = false)
    {
        if (deck.cards.Count > 0)
        {
            if (hand.CardsInHand.Count < PArea.handVisual.slots.Children.Length)
            {
                // 1) logic: Agregar carta a la mano
                CardLogic newCard = new CardLogic(deck.cards[0]);
                newCard.owner = this;
                hand.CardsInHand.Insert(0, newCard);

                // 2) logic: Quitar carta del deck
                deck.cards.RemoveAt(0);
                // 2) Crear comando
                new DrawACardCommand(hand.CardsInHand[0], this, fast, fromDeck: true).AddToQueue();
            }
        }
        else
        {
            // No hay cartas en el deck
            new DealDamageCommand(TurnManager.Instance.whoseTurn.PlayerID, 2, TurnManager.Instance.whoseTurn.Health - 10).AddToQueue();
            TurnManager.Instance.whoseTurn.Health -= 25;
        }

    }

    // Sacar Subdito-Coincard
    public void GetACardNotFromDeck(CardAsset cardAsset)
    {
        if (hand.CardsInHand.Count < PArea.handVisual.slots.Children.Length)
        {
            // 1) logic: Agregar a la mano
            CardLogic newCard = new CardLogic(cardAsset);
            newCard.owner = this;
            hand.CardsInHand.Insert(0, newCard);

            // 2) Enviar orden al deck visual
            new DrawACardCommand(hand.CardsInHand[0], this, fast: true, fromDeck: false).AddToQueue();
        }
        //No se quita del deck porque la coincard no viene de ahi
    }

    public void PlayASpellFromHand(int SpellCardUniqueID, int TargetUniqueID)
    {
        // TODO: !!!
        // if TargetUnique ID < 0 , for example = -1, there is no target.
        if (TargetUniqueID < 0)
            PlayASpellFromHand(CardLogic.CardsCreatedThisGame[SpellCardUniqueID], null);
        else if (TargetUniqueID == ID)
        {
            PlayASpellFromHand(CardLogic.CardsCreatedThisGame[SpellCardUniqueID], this);
        }
        else if (TargetUniqueID == otherPlayer.ID)
        {
            PlayASpellFromHand(CardLogic.CardsCreatedThisGame[SpellCardUniqueID], this.otherPlayer);
        }
        else
        {
            // target is a creature
            PlayASpellFromHand(CardLogic.CardsCreatedThisGame[SpellCardUniqueID], CreatureLogic.CreaturesCreatedThisGame[TargetUniqueID]);
        }
          
    }

    public void PlayASpellFromHand(CardLogic playedCard, ICharacter target)
    {
        MovementLeft -= playedCard.CurrentMovementCost;
        // Efecto inmediato:
        if (playedCard.effect != null)
            playedCard.effect.ActivateEffect(playedCard.ca.specialSpellAmount, target);
        else
        {
            Debug.LogWarning("Esta carta no tiene efecto " + playedCard.ca.name);
        }
        // Enviar carta solo a slot 
        new PlayASpellCardCommand(this, playedCard).AddToQueue();
        // Quitar de la mano
        hand.CardsInHand.Remove(playedCard);
        // check if this is a creature or a spell
    }

    public void PlayACreatureFromHand(int UniqueID, int tablePos)
    {
        PlayACreatureFromHand(CardLogic.CardsCreatedThisGame[UniqueID], tablePos);
    }

    public void PlayACreatureFromHand(CardLogic playedCard, int tablePos)
    {
        // Quitar movimientos
        MovementLeft -= playedCard.CurrentMovementCost;
        
        // Crear una leyenda y agregarla a Table
        CreatureLogic newCreature = new CreatureLogic(this, playedCard.ca);
        table.CreaturesOnTable.Insert(tablePos, newCreature);
       
        // Siempre mover la carta al Slot
        new PlayACreatureCommand(playedCard, this, tablePos, newCreature.UniqueCreatureID).AddToQueue();
        
        // Quitar de la mano
        hand.CardsInHand.Remove(playedCard);
    }

    public void Die()
    {
        // game over
        // block both players from taking new moves 
        PArea.ControlsON = false;
        otherPlayer.PArea.ControlsON = false;
        TurnManager.Instance.StopTheTimer();
        new GameOverCommand(this).AddToQueue();
    }



    // METHODS TO SHOW GLOW HIGHLIGHTS
    public void HighlightPlayableCards(bool removeAllHighlights = false)
    {

        foreach (CardLogic cl in hand.CardsInHand)
        {
            GameObject g = IDHolder.GetGameObjectWithID(cl.UniqueCardID);
            if (g != null)
                g.GetComponent<OneCardManager>().CanBePlayedNow = (cl.CurrentMovementCost <= MovementLeft) && !removeAllHighlights;
        }

        foreach (CreatureLogic crl in table.CreaturesOnTable)
        {
            GameObject g = IDHolder.GetGameObjectWithID(crl.UniqueCreatureID);
            if(g!= null)
                g.GetComponent<OneCreatureManager>().CanAttackNow = (crl.AttacksLeftThisTurn > 0) && !removeAllHighlights;
        }
            
    }

    // START GAME METHODS
    public void LoadCharacterInfoFromAsset()
    {
        Health = charAsset.MaxHealth;
        // change the visuals for portrait, hero power, etc...
        PArea.Portrait.charAsset = charAsset;
        PArea.Portrait.ApplyLookFromAsset();
        // TODO: insert the code to attach hero power script here. 
        if (charAsset.HeroPowerName != null && charAsset.HeroPowerName != "")
        {
            HeroPowerEffect = System.Activator.CreateInstance(System.Type.GetType(charAsset.HeroPowerName)) as SpellEffect;

        }
        else
        {
            Debug.LogWarning("Check hero powr name for character " + charAsset.ClassName);
        }
    }

    public void TransmitInfoAboutPlayerToVisual()
    {
        PArea.Portrait.gameObject.AddComponent<IDHolder>().UniqueID = PlayerID;
        if (GetComponent<TurnMaker>() is AITurnMaker)
        {
            // turn off turn making for this character
            PArea.AllowedToControlThisPlayer = false;
        }
        else
        {
            // allow turn making for this character
            PArea.AllowedToControlThisPlayer = true;
        }
    }

    public void UseHeroPower()
    {
        MovementLeft -= 2;
        usedHeroPowerThisTurn = true;
        HeroPowerEffect.ActivateEffect();
    }
}
