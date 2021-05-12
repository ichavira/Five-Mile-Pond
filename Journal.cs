using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    #region Singleton

    public static Journal instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Journal instance exists.");
            return;
        }
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public List<Item> items = new List<Item>();
    public List<Speaker> characters = new List<Speaker>();
    public List<Task> tasks = new List<Task>();
    public List<Location> locations = new List<Location>();

    public bool isActive = false;


    public void AddItem (Item item)
    {
        items.Add(item);
        TriggerCallback();
    }

    public void AddCharacter(Speaker character)
    {
        characters.Add(character);
        TriggerCallback();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
        TriggerCallback();
    }

    public void AddLocation(Location loc)
    {
        locations.Add(loc);
        TriggerCallback();
    }

    public void CompleteTask(Task task)
    {
        task.completed = true;
        TriggerCallback();
    }

    //Not sure if we will ever use this
    public void Remove (Item item)
    {
        items.Remove(item);
        TriggerCallback();
    }

    public void TriggerCallback()
    {
        //Event trigger to update UI
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

}
