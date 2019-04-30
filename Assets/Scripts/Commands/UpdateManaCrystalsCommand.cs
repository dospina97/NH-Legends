using UnityEngine;
using System.Collections;

public class UpdateManaCrystalsCommand : Command {

    private Player p;
    private int TotalMovement;
    private int AvailableMovement;

    public UpdateManaCrystalsCommand(Player p, int TotalMovement, int AvailableMovement)
    {
        this.p = p;
        this.TotalMovement = TotalMovement;
        this.AvailableMovement = AvailableMovement;
    }

    public override void StartCommandExecution()
    {
        p.PArea.ManaBar.TotalCrystals = TotalMovement;
        p.PArea.ManaBar.AvailableCrystals = AvailableMovement;
        CommandExecutionComplete();
    }
}
