using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameOverCommand : Command{

    private Player looser;
    public int gameOverCount;

    public GameOverCommand(Player looser)
    {
        this.looser = looser;
        gameOverCount++;
        Analytics.CustomEvent("Deads", new Dictionary<string, object> {
            {"NumberofGameovers",gameOverCount}

             });
        
    }

    public override void StartCommandExecution()
    {
        looser.PArea.Portrait.Explode();
    }

    



}
