using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one DialogueManager instance exists.");
            return;
        }
        instance = this;
        animator = GetComponent<Animator>();
    }

    #endregion

    public Text nameText;
    public Text dialogueText;
    public Button continueButton;
    public Image speakerSprite;

    private Animator animator;

    private int currentIndex;
    private Conversation currentConvo;
    private Coroutine typing;

    public bool isActive;


    public static void StartDialogue(Conversation convo)
    {
        if (instance.isActive)
        {
            return;
        }
        instance.isActive = true;
        instance.currentIndex = 0;
        instance.animator.SetBool("isOpen", true);
        instance.currentConvo = convo;
        instance.nameText.text = "";
        instance.dialogueText.text = "";
        instance.continueButton.GetComponentInChildren<Text>().text = ">";

        instance.DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (currentIndex > currentConvo.GetLength())
        {
            EndDialogue();
            return;
        }
        //Update button to close window UI
        if (currentIndex == currentConvo.GetLength())
        {
            instance.continueButton.GetComponentInChildren<Text>().text = "X";
        }

        nameText.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        string sentence = currentConvo.GetLineByIndex(currentIndex).dialogue;

        if (typing == null)
        {
            typing = instance.StartCoroutine(TypeSentence(sentence));
        }
        else
        {
            //Stop typing and instant complete sentence
            instance.StopCoroutine(typing);
            typing = null;
            dialogueText.text = sentence;
            currentIndex++;
        }
    }

    //Types dialogue line letter by letter
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        yield return new WaitForSeconds(.2f);

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.03f);
        }
        typing = null;
        currentIndex++;
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        instance.isActive = false;
        Debug.Log("End of dialogue");
        currentConvo.hadConversation = true;
    }


}
