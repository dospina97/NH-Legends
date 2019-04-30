using UnityEngine;
using System.Collections;

public class GiveMovementBonus: SpellEffect 
{
    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
        TurnManager.Instance.whoseTurn.GetBonusMovement(specialAmount);
    }
}
