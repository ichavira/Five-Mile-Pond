using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Journal/New Location")]
public class Location : ScriptableObject
{
    [SerializeField] private string locationName;
    [SerializeField] private Sprite locationSprite;
    [TextArea(2, 8)]
    [SerializeField] private string locationDescription;

    public string GetName()
    {
        return locationName;
    }


    public Sprite GetSprite()
    {
        return locationSprite;
    }

    public string GetDescription()
    {
        return locationDescription;
    }
}
