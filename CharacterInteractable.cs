using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractable : Interactable
{
    public GameObject currentObj;
    //public Speaker speaker;
    public Conversation convo;
    public GameObject toActivate;

    private void Update()
    {
        if (toActivate != null)
        {
            if (convo.hadConversation)
            {
                toActivate.SetActive(true);
            }
        }
    }

    public override void Interact()
    {
        Debug.Log("Interaction started");
        DialogueManager.StartDialogue(convo);

        // Write into journal
        if (!convo.hadConversation)
        {
            if (convo.GetSpeakers().Length > 0)
            {
                foreach (Speaker sp in convo.GetSpeakers())
                {
                    Debug.Log("Adding " + sp.GetName() + " to journal.");
                    Journal.instance.AddCharacter(sp);
                }
            }

            if (convo.GetLocations().Length > 0)
            {
                foreach (Location loc in convo.GetLocations())
                {
                    Debug.Log("Adding " + loc.GetName() + " to journal.");
                    Journal.instance.AddLocation(loc);
                }
            }

            if (convo.GetTaskToDo() != null)
            {
                Journal.instance.AddTask(convo.GetTaskToDo());
            }
            if (convo.GetTaskCompleted() != null)
            {
                Journal.instance.CompleteTask(convo.GetTaskCompleted());
            }
        }

    }
}
