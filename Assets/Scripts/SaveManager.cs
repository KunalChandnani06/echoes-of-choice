using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveNPC(NPCData npc)
    {
        PlayerPrefs.SetInt(
            npc.npcName + "_Friendship",
            npc.friendship
        );

        PlayerPrefs.SetInt(
            npc.npcName + "_Stage",
            npc.conversationStage
        );

        PlayerPrefs.SetInt(
            npc.npcName + "_MetPlayer",
            npc.metPlayer ? 1 : 0
        );

        PlayerPrefs.Save();
    }

    public static void LoadNPC(NPCData npc)
    {
        npc.friendship = PlayerPrefs.GetInt(
            npc.npcName + "_Friendship",
            0
        );

        npc.conversationStage = PlayerPrefs.GetInt(
            npc.npcName + "_Stage",
            0
        );

        npc.metPlayer =
            PlayerPrefs.GetInt(
                npc.npcName + "_MetPlayer",
                0
            ) == 1;
    }
}