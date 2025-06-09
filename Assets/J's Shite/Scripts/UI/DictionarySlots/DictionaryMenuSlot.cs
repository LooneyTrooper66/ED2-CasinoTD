using UnityEngine;

[CreateAssetMenu(fileName = "DictionaryMenuSlot", menuName = "Scriptable Objects/DictionaryMenuSlot")]
public class DictionaryMenuSlot : ScriptableObject
{
    public string thingName;
    public Sprite sprite;
    [TextArea(4, 4)]
    public string description;
}
