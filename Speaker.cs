using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/New Speaker")]
public class Speaker : ScriptableObject
{
    [SerializeField] private string speakerName;
    [SerializeField] private Sprite speakerSprite;
    [TextArea(2, 8)]
    [SerializeField] private string speakerDescription;

    public string GetName()
    {
        return speakerName;
    }


    public Sprite GetSprite()
    {
        return speakerSprite;
    }

    public string GetDescription() 
    { 
        return speakerDescription;
    }
}
