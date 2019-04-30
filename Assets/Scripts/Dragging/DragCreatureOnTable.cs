using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class DragCreatureOnTable : DraggingActions {

    private int savedHandSlot;
    private WhereIsTheCardOrCreature whereIsCard;
    private IDHolder idScript;
    private VisualStates tempState;
    private OneCardManager manager;

    public override bool CanDrag
    {
        get
        {
          //include full field check
            return base.CanDrag && manager.CanBePlayedNow;

        }
    }

    void Awake()
    {
        whereIsCard = GetComponent<WhereIsTheCardOrCreature>();
        manager = GetComponent<OneCardManager>();
    }

    public override void OnStartDrag()
    {
        savedHandSlot = whereIsCard.Slot;
        tempState = whereIsCard.VisualState;
        whereIsCard.VisualState = VisualStates.Dragging;
        whereIsCard.BringToFront();

    }

    public override void OnDraggingInUpdate()
    {

    }

    public override void OnEndDrag()
    {
        
        // 1) Check if we are holding a card over the table
        if (DragSuccessful())
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            // determine table position
            int tablePos = playerOwner.PArea.tableVisual.TablePosForNewCreature(Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)).x);
            // play this card
            playerOwner.PlayACreatureFromHand(GetComponent<IDHolder>().UniqueID, tablePos);

#elif UNITY_ANDROID || UNITY_IPHONE
             int tablePos = playerOwner.PArea.tableVisual.TablePosForNewCreature(Camera.main.ScreenToWorldPoint(
                new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z - Camera.main.transform.position.z)).x);
              
            playerOwner.PlayACreatureFromHand(GetComponent<IDHolder>().UniqueID, tablePos);
#endif
        }
        else
        {
            // Set old sorting order 
            whereIsCard.SetHandSortingOrder();
            whereIsCard.VisualState = tempState;
            // Move this card back to its slot position
            HandVisual PlayerHand = playerOwner.PArea.handVisual;
            Vector3 oldCardPos = PlayerHand.slots.Children[savedHandSlot].transform.localPosition;
            transform.DOLocalMove(oldCardPos, 1f);
        } 
    }

    protected override bool DragSuccessful()
    {
        bool TableNotFull = (playerOwner.table.CreaturesOnTable.Count < 5);

        return TableVisual.CursorOverSomeTable && TableNotFull;
    }
}
