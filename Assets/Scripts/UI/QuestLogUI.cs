using UnityEngine;
using TMPro;
using System.Text;

public class QuestLogUI : MonoBehaviour
{
    public static QuestLogUI Instance;

    public GameObject questLogPanel;
    public TMP_Text questLogText;

    private bool isOpen = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleQuestLog();
        }

        if (isOpen)
        {
            RefreshQuestLog();
        }
    }

    void ToggleQuestLog()
    {
        isOpen = !isOpen;

        questLogPanel.SetActive(isOpen);

        if (isOpen)
        {
            RefreshQuestLog();
        }
    }

    public void RefreshQuestLog()
    {
        StringBuilder builder =
            new StringBuilder();

        builder.AppendLine("QUEST LOG");
        builder.AppendLine("");

        NPCData[] npcs =
            FindObjectsByType<NPCData>(
                FindObjectsSortMode.None
            );

        foreach (NPCData npc in npcs)
        {
            if (npc.quest.isAccepted)
            {
                builder.AppendLine(
                    npc.quest.questName
                );

                builder.AppendLine(
                    npc.quest.isCompleted
                    ? "Status: Completed"
                    : "Status: Active"
                );

                builder.AppendLine("");
            }
        }

        if (builder.ToString() == "QUEST LOG\n\n")
        {
            builder.AppendLine(
                "No Active Quests"
            );
        }

        questLogText.text =
            builder.ToString();
    }
}