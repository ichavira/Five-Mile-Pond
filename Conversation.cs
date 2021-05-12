using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue/New Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] private DialogueLine[] lines;
    [SerializeField] private Task taskToDo;
    [SerializeField] private Task taskCompleted;
    [SerializeField] private Speaker[] speakersToAdd;
    [SerializeField] private Location[] locationsToAdd;
    public bool hadConversation = false;

    public void Awake()
    {
        hadConversation = false;
    }
    public DialogueLine GetLineByIndex(int index)
    {
        return lines[index];
    }

    public int GetLength()
    {
        return lines.Length - 1;
    }

    public Task GetTaskToDo()
    {
        return taskToDo;
    }

    public Task GetTaskCompleted()
    {
        return taskCompleted;
    }

    public Speaker[] GetSpeakers()
    {
        return speakersToAdd;
    }

    public Location[] GetLocations()
    {
        return locationsToAdd;
    }
}

