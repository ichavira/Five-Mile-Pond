using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    #region Singleton
    public static ItemManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one ItemManager instance exists.");
            return;
        }
        instance = this;
        instance.itemPanel.localScale = new Vector2(0, 0);
        instance.letterPanel.localScale = new Vector2(0, 0);
    }

    #endregion

    public RectTransform itemPanel;
    public Text nameText;
    public Text desciptionText;
    public Button exitButton;
    public Image itemSprite;

    public RectTransform letterPanel;
    public Text letterText;

    public bool isActive;


    public static void DisplayItem(Item obj)
    {
        if (instance.isActive)
        {
            return;
        }
        // Populate item panel info
        instance.itemPanel.localScale = new Vector2(1, 1);
        instance.isActive = true;
        instance.nameText.text = obj.GetName();
        instance.desciptionText.text = obj.GetDescription();
        instance.itemSprite.sprite = obj.GetSprite();
    }

    public static void DisplayLetter(Item obj)
    {
        if (instance.isActive)
        {
            return;
        }
        instance.letterPanel.localScale = new Vector2(1, 1);
        instance.isActive = true;
        instance.letterText.text = obj.GetDescription();
    }

    public void ExitDisplay()
    {
        instance.itemPanel.localScale = new Vector2(0, 0);
        instance.letterPanel.localScale = new Vector2(0, 0);
        instance.isActive = false;
    }
}
