using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    [TextArea(2, 8)]
    [SerializeField] private string itemDescription;

    public string GetName()
    {
        return itemName;
    }


    public Sprite GetSprite()
    {
        return itemSprite;
    }

    public string GetDescription()
    {
        return itemDescription;
    }

    
}