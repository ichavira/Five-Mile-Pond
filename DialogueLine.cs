using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker;

    [TextArea(2, 8)]
    public string dialogue;
}