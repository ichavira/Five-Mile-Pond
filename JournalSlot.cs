using UnityEngine;
using UnityEngine.UI;

public class JournalSlot : MonoBehaviour
{
    public Image icon;
    public Text objName, description;
    public GameObject textArea;
    public Image taskCheck;
    Item item;
    Speaker character;
    Task task;
    Location loc;


    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.GetSprite();
        objName.text = item.GetName();
        description.text = item.GetDescription();
        textArea.SetActive(true);
        icon.enabled = true;
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void AddCharacter(Speaker newCharacter)
    {
        character = newCharacter;

        icon.sprite = character.GetSprite();
        objName.text = character.GetName();
        description.text = character.GetDescription();
        textArea.SetActive(true);
        icon.enabled = true;
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void AddTask(Task newTask)
    {
        task = newTask;
        description.text = task.GetTask();
        icon.enabled = true;
        textArea.SetActive(true);
        taskCheck.enabled = false;
    }

    public void AddLocation(Location newLoc)
    {
        loc = newLoc;

        icon.sprite = loc.GetSprite();
        objName.text = loc.GetName();
        description.text = loc.GetDescription();
        textArea.SetActive(true);
        icon.enabled = true;
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void CompleteTask(Task taskComplete)
    {
        task = taskComplete;
        description.text = task.GetTask();
        textArea.SetActive(true);
        icon.enabled = true;
        taskCheck.enabled = true;
    }


    public void OnItemClick()
    {
        Debug.Log("Item clicked.");
    }
}
