using UnityEngine;
using System.Collections;

public class BiteOwner : CreatureEffect
{  
    public BiteOwner(Player owner, CreatureLogic creature, int specialAmount): base(owner, creature, specialAmount)
    {}

    public override void RegisterEffect()
    {
        owner.EndTurnEvent += CauseEffect;
       
    }

    public override void CauseEffect()
    {

        new DealDamageCommand(owner.PlayerID, specialAmount, owner.Health - specialAmount).AddToQueue();
        owner.Health -= specialAmount;
    }


}
