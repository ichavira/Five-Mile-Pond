using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class JournalUI : MonoBehaviour
{
    public GameObject journalUI;
    public Button journalButton;

    public Transform[] charactersParent;
    public Transform[] itemsParent;
    public Transform tasksParent;
    public Transform locationsParent;
    
    List<JournalSlot[]> characterSlots;
    List<JournalSlot[]> itemSlots;
    JournalSlot[] taskSlots;
    JournalSlot[] locationSlots;

    Journal journal;
    // Start is called before the first frame update
    void Start()
    {
        journal = Journal.instance;
        journal.onItemChangedCallback += UpdateUI;

        //Move to Update() if slots are not static
        itemSlots = new List<JournalSlot[]>();
        taskSlots = tasksParent.GetComponentsInChildren<JournalSlot>();
        locationSlots = locationsParent.GetComponentsInChildren<JournalSlot>();
        characterSlots = new List<JournalSlot[]>();
        foreach (Transform par in charactersParent)
        {
            characterSlots.Add(par.GetComponentsInChildren<JournalSlot>());
        }
        foreach (Transform par in itemsParent)
        {
            itemSlots.Add(par.GetComponentsInChildren<JournalSlot>());
        }

        DontDestroyOnLoad(transform.gameObject);
    }


    void UpdateUI()
    {
        Debug.Log("Updating Journal UI");
        // could do some kind of switch statement here , but ... not yet
        for (int i = 0; i < itemSlots.Count; i++)
        {
            for (int j = 0; j < itemSlots[i].Length; j++)
            {
                //this is hard coded im so sorry
                if (j + (i * 8) < journal.items.Count)
                {
                    itemSlots[i][j].AddItem(journal.items[j + (i * 8)]);
                }
            }

        }
        //Populate UI data for new characters
        for (int i = 0; i < characterSlots.Count; i++)
        {
            for (int j = 0; j < characterSlots[i].Length; j++)
            {
                //this is hard coded im so sorry
                if (j+(i*8) < journal.characters.Count)
                {
                    characterSlots[i][j].AddCharacter(journal.characters[j + (i*8)]);
                }
            }

        }
        //Populate UI data for new tasks
        for (int i = 0; i < taskSlots.Length; i++)
        {
            if (i < journal.tasks.Count)
            {
                taskSlots[i].AddTask(journal.tasks[i]);
                if (journal.tasks[i].completed)
                {
                    taskSlots[i].CompleteTask(journal.tasks[i]);
                }
            }
        }
        //Populate UI data for new locations
        for (int i = 0; i < locationSlots.Length; i++)
        {
            if (i < journal.locations.Count)
            {
                locationSlots[i].AddLocation(journal.locations[i]);
            }
        }

    }

    public void OpenJournal()
    {
        journalUI.SetActive(true);
        journal.isActive = true;
        journalButton.gameObject.SetActive(false);
    }

    public void CloseJournal()
    {
        journalUI.SetActive(false);
        journal.isActive = false;
        journalButton.gameObject.SetActive(true);
    }
}
