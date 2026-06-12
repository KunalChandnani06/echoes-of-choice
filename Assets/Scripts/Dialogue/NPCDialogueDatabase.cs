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

                    if (!npc.quest.isAccepted)
                    {
                        return npc.npcName +
                               ":\nMy best friend is here!\n\n" +
                               "I lost my notebook.\n\n" +
                               "1 - I'll help you find it.\n" +
                               "2 - Maybe later.";
                    }

                    if (!npc.quest.isCompleted)
                    {
                        return npc.npcName +
                               ":\nHave you found my notebook yet?";
                    }

                    return npc.npcName +
                           ":\nThank you for finding my notebook!";
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

                    if (!npc.quest.isAccepted)
                    {
                        return npc.npcName +
                               ":\nI was hoping you'd stop by.\n\n" +
                               "I lost my flower.\n\n" +
                               "1 - I'll help you find it.\n" +
                               "2 - Maybe later.";
                    }

                    if (!npc.quest.isCompleted)
                    {
                        return npc.npcName +
                               ":\nHave you found my flower yet?";
                    }

                    return npc.npcName +
                           ":\nThank you for finding my flower!";
            }
        }
        if (npc.personalityType == "Shy")
        {
            switch (npc.conversationStage)
            {
                case 0:
                    return npc.npcName +
                           ":\nOh... hello.\n\n" +
                           "1 - Be friendly\n" +
                           "2 - Stay quiet\n" +
                           "3 - Walk away";

                case 1:
                    return npc.npcName +
                           ":\nI don't talk to many people.\n\n" +
                           "1 - Encourage her\n" +
                           "2 - Change topic\n" +
                           "3 - Ignore";

                case 2:
                    return npc.npcName +
                           ":\nYou're easier to talk to.\n\n" +
                           "1 - Be supportive\n" +
                           "2 - Stay neutral\n" +
                           "3 - Tease";

                case 3:
                    return npc.npcName +
                           ":\nCan I ask a favor?\n\n" +
                           "1 - Sure\n" +
                           "2 - Maybe later\n" +
                           "3 - Refuse";

                default:

                    if (!npc.quest.isAccepted)
                    {
                        return npc.npcName +
                               ":\nI lost an old photo.\n\n" +
                               "1 - I'll help find it.\n" +
                               "2 - Maybe later.";
                    }

                    if (!npc.quest.isCompleted)
                    {
                        return npc.npcName +
                               ":\nHave you found my photo?";
                    }

                    return npc.npcName +
                           ":\nThank you for finding it.";
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