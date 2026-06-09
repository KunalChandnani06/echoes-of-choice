using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AcceptQuest(NPCData npc)
    {
        npc.quest.isAccepted = true;

        NotificationManager.Instance.ShowNotification(
            "Quest Accepted:\n" +
            npc.quest.questName
        );

        Debug.Log(
            "Quest Accepted: " +
            npc.quest.questName
        );
    }

    public void CompleteQuest(NPCData npc)
    {
        if (!npc.quest.isAccepted)
            return;

        if (npc.quest.isCompleted)
            return;

        npc.quest.isCompleted = true;

        npc.friendship += npc.quest.friendshipReward;

        SaveManager.SaveNPC(npc);

        NotificationManager.Instance.ShowNotification(
            "Quest Completed!\n" +
            npc.quest.questName +
            "\nFriendship +" +
            npc.quest.friendshipReward
        );

        Debug.Log(
            "Quest Completed: " +
            npc.quest.questName
        );
    }
}