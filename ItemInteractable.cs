using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    public Item currentItem;
    public Task taskToDo;
    public Task taskCompleted;
    public bool addToJournal;
    public GameObject toActivate;
    public GameObject toDeactivate;
    public bool isLetter;

    public override void Interact()
    {
        Debug.Log("Object interaction started");
        if (isLetter)
        {
            ItemManager.DisplayLetter(currentItem);
        }
        else
        {
            ItemManager.DisplayItem(currentItem);
        }
        if (addToJournal)
        {
            PickUp();
        }
        if (taskToDo != null)
        {
            Journal.instance.AddTask(taskToDo);
        }
        if (taskCompleted != null)
        {
            Journal.instance.CompleteTask(taskCompleted);
        }
    }

    void PickUp()
    {
        Debug.Log("Picking up " + currentItem.GetName());
        //Add to inventory
        Journal.instance.AddItem(currentItem);
        //Complete any triggers
        if (toActivate != null)
        {
            toActivate.SetActive(true);
        }
        if (toDeactivate != null)
        {
            toDeactivate.SetActive(false);
        }
        //Remove from scene
        Destroy(gameObject);
    }
}
