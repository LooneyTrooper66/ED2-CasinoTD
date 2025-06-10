using UnityEngine;
using UnityEngine.UI;

public class SlotSetUI : MonoBehaviour
{
    [SerializeField] private Text thingName;
    [SerializeField] private Text thingDescription;
    [SerializeField] private Image thingSprite;


    public void InitSlot(string name, string description, Sprite sprite)
    {
        thingName.text = name;
        thingDescription.text = description;
        thingSprite.sprite = sprite;
    }
}
