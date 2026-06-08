using UnityEngine;

public static class NPCDialogueDatabase
{
    public static string GetStageDialogue(NPCData npc)
    {
        if (npc.personalityType == "Friendly")
        {
            switch (npc.conversationStage)
            {
                case 0:
                    return npc.npcName +
                           ":\nHey, nice to meet you.\n\n" +
                           "1 - Nice to meet you too.\n" +
                           "2 - Ignore him.\n" +
                           "3 - Tell a joke.";

                case 1:
                    return npc.npcName +
                           ":\nWhat do you usually do for fun?\n\n" +
                           "1 - Talk about hobbies\n" +
                           "2 - Change topic\n" +
                           "3 - Leave";

                case 2:
                    return npc.npcName +
                           ":\nWant to hear about my favorite hobby?\n\n" +
                           "1 - Listen\n" +
                           "2 - Not interested\n" +
                           "3 - Make a joke";

                case 3:
                    return npc.npcName +
                           ":\nCan I tell you something personal?\n\n" +
                           "1 - Listen carefully\n" +
                           "2 - Ignore\n" +
                           "3 - Interrupt";

                default:
                    return npc.npcName +
                           ":\nMy best friend is here!";
            }
        }

        if (npc.personalityType == "Serious")
        {
            switch (npc.conversationStage)
            {
                case 0:
                    return npc.npcName +
                           ":\nHello. What do you need?\n\n" +
                           "1 - Compliment her\n" +
                           "2 - Introduce yourself\n" +
                           "3 - Act arrogant";

                case 1:
                    return npc.npcName +
                           ":\nI've been busy working lately.\n\n" +
                           "1 - Encourage her\n" +
                           "2 - Ask about work\n" +
                           "3 - Interrupt";

                case 2:
                    return npc.npcName +
                           ":\nNot many people understand me.\n\n" +
                           "1 - Listen\n" +
                           "2 - Change subject\n" +
                           "3 - Dismiss her feelings";

                case 3:
                    return npc.npcName +
                           ":\nI trust you enough to tell you this.\n\n" +
                           "1 - Support her\n" +
                           "2 - Stay neutral\n" +
                           "3 - Judge her";

                default:
                    return npc.npcName +
                           ":\nI was hoping you'd stop by.";
            }
        }

        return npc.npcName + ":\n...";
    }

    public static int GetFriendshipChange(int choice)
    {
        switch (choice)
        {
            case 1:
                return 5;

            case 2:
                return 1;

            case 3:
                return -3;

            default:
                return 0;
        }
    }
}