using UnityEngine;
using System.Collections;

public class HeroPowerDrawCardTakeDamage : SpellEffect {

    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
        // Take 50 damage
        new DealDamageCommand(TurnManager.Instance.whoseTurn.PlayerID, 2, TurnManager.Instance.whoseTurn.Health - 50).AddToQueue();
        TurnManager.Instance.whoseTurn.Health -= 50;
        // Draw a card
        TurnManager.Instance.whoseTurn.DrawACard();

    }
}
