using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Journal/New Task")]
public class Task : ScriptableObject
{
    [TextArea(2, 8)]
    [SerializeField] private string task;
    public bool completed;

    public string GetTask()
    {
        return task;
    }


}
