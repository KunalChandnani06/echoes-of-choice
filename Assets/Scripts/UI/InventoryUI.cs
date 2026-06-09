using UnityEngine;
using TMPro;
using System.Text;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    public GameObject inventoryPanel;
    public TMP_Text inventoryText;

    private bool isOpen = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        if (isOpen)
        {
            RefreshInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;

        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            RefreshInventory();
        }
    }

    public void RefreshInventory()
    {
        StringBuilder builder =
            new StringBuilder();

        builder.AppendLine("INVENTORY");
        builder.AppendLine("");

        foreach (InventoryItem item in
                 InventoryManager.Instance.items)
        {
            builder.AppendLine(
                item.itemName +
                " x" +
                item.quantity
            );
        }

        if (InventoryManager.Instance.items.Count == 0)
        {
            builder.AppendLine("Empty");
        }

        inventoryText.text =
            builder.ToString();
    }
}