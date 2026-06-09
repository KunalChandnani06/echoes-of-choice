using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> items =
        new List<InventoryItem>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(string itemName)
    {
        foreach (InventoryItem item in items)
        {
            if (item.itemName == itemName)
            {
                item.quantity++;

                Debug.Log(
                    itemName +
                    " x" +
                    item.quantity
                );

                return;
            }
        }

        InventoryItem newItem =
            new InventoryItem();

        newItem.itemName = itemName;
        newItem.quantity = 1;

        items.Add(newItem);

        Debug.Log(
            itemName +
            " added to inventory"
        );
    }

    public bool HasItem(string itemName)
    {
        foreach (InventoryItem item in items)
        {
            if (item.itemName == itemName &&
                item.quantity > 0)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(string itemName)
    {
        foreach (InventoryItem item in items)
        {
            if (item.itemName == itemName)
            {
                item.quantity--;

                return;
            }
        }
    }
}