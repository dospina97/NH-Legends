using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneReloader: MonoBehaviour {

    public void ReloadScene()
    {
        // Command has some static members, so let`s make sure that there are no commands in the Queue
        Debug.Log("Scene reloaded");
        // reset all card and creature IDs
        IDFactory.ResetIDs();
        IDHolder.ClearIDHoldersList();
        Command.CommandQueue.Clear();
        Command.CommandExecutionComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        // Command has some static members, so let`s make sure that there are no commands in the Queue
        Debug.Log("Scene reloaded");
        // reset all card and creature IDs
        IDFactory.ResetIDs();
        IDHolder.ClearIDHoldersList();
        Command.CommandQueue.Clear();
        Command.CommandExecutionComplete();
        SceneManager.LoadScene(0);
    }

    public void SimpleGoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToInventory()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToStore()
    {
        SceneManager.LoadScene(3);
    }


}
