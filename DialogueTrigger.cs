using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation convo;
    public bool cutscene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!convo.hadConversation)
            {
                //convo.hadConversation = true;
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
            if (cutscene)
            {
                StartCoroutine(StartDialogue(convo));
            } else
            {
                DialogueManager.StartDialogue(convo);
                Destroy(gameObject);
            }
            
        }
    }

    IEnumerator StartDialogue(Conversation conversation)
    {
        // Wait
        yield return new WaitForSeconds(.7f);
        // Start Dialogue
        DialogueManager.StartDialogue(conversation);
        Destroy(gameObject);
    }
}
