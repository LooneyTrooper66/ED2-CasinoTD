using UnityEngine;

[CreateAssetMenu(fileName = "DictionaryMenuSlot", menuName = "Scriptable Objects/DictionaryMenuSlot")]
public class DictionaryMenuSlot : ScriptableObject
{
    public Sprite sprite;
    public string thingName;
    [TextArea(4, 4)]
    public string description;
}
