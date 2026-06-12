using UnityEngine;
using TMPro;
using System.Text;

public class RelationshipUI : MonoBehaviour
{
    public GameObject relationshipPanel;

    public TMP_Text relationshipText;

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleRelationships();
        }

        if (isOpen)
        {
            RefreshRelationships();
        }
    }

    void ToggleRelationships()
    {
        isOpen = !isOpen;

        relationshipPanel.SetActive(isOpen);

        if (isOpen)
        {
            RefreshRelationships();
        }
    }

    void RefreshRelationships()
    {
        StringBuilder builder =
            new StringBuilder();

        builder.AppendLine("RELATIONSHIPS");
        builder.AppendLine("");

        NPCData[] npcs =
            FindObjectsByType<NPCData>(
                FindObjectsSortMode.None
            );

        foreach (NPCData npc in npcs)
        {
            string rank = "Stranger";

            if (npc.friendship >= 100)
                rank = "Best Friend";
            else if (npc.friendship >= 50)
                rank = "Close Friend";
            else if (npc.friendship >= 20)
                rank = "Friend";

            builder.AppendLine(
                npc.npcName
            );

            builder.AppendLine(
                "Friendship: " +
                npc.friendship
            );

            builder.AppendLine(
                "Status: " +
                rank
            );

            builder.AppendLine("");
        }

        relationshipText.text =
            builder.ToString();
    }
}