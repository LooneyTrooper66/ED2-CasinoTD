using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GridLayoutGroup contents;
    [SerializeField] private List<DictionaryMenuSlot> thingsList = new List<DictionaryMenuSlot>();


    private void Start()
    {
        InitializeSlots();
    }

    void InitializeSlots()
    {
        foreach (DictionaryMenuSlot thingSlot in thingsList)
        {
            var dictSlot = Instantiate(slotPrefab, contents.transform);

            dictSlot.GetComponent<SlotSetUI>().InitSlot(thingSlot.thingName, thingSlot.description, thingSlot.sprite);
        }
    }
}
