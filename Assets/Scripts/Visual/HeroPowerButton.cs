using UnityEngine;
using System.Collections;

public class HeroPowerButton : MonoBehaviour {

    public AreaPosition owner;

    public GameObject Front;
    public GameObject Back;

    private bool wasUsed = false;
    public bool WasUsedThisTurn
    { 
        get
        {
            return wasUsed;
        } 
        set
        {
            wasUsed = value;
            if (!wasUsed)
            {
                Front.SetActive(true);
                Back.SetActive(false);
            }
            else
            {
                Front.SetActive(false);
                Back.SetActive(true);

            }
        }
    }

 

    void OnMouseDown()
    {
        if (!WasUsedThisTurn)
        {
            GlobalSettings.Instance.Players[owner].UseHeroPower();
            WasUsedThisTurn= !WasUsedThisTurn;
        }
    }
}
