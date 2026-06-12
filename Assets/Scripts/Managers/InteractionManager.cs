using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private bool isOpen = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NPCInteraction.playerNearNPC)
        {
            if (!isOpen)
            {
                OpenDialogue();
            }
            else
            {
                CloseDialogue();
            }
        }

        if (isOpen)
        {
            HandleChoices();
        }
    }

    void OpenDialogue()
    {
        if (NPCInteraction.currentNPC == null)
            return;

        isOpen = true;

        dialoguePanel.SetActive(true);

        PlayerMovement.canMove = false;

        NPCData npc = NPCInteraction.currentNPC;

        string requiredItem =
            GetQuestItemName(npc);

        if (npc.quest.isAccepted &&
            !npc.quest.isCompleted &&
            InventoryManager.Instance.HasItem(requiredItem))
        {
            dialogueText.text =
                npc.npcName +
                ":\nYou found my " +
                requiredItem +
                "!\n\n" +
                "1 - Return " +
                requiredItem;

            return;
        }

        dialogueText.text =
            NPCDialogueDatabase.GetStageDialogue(npc);
    }

    void HandleChoices()
    {
        if (NPCInteraction.currentNPC == null)
            return;

        NPCData npc = NPCInteraction.currentNPC;

        if (npc.conversationStage >= 4)
        {
            HandleQuestChoices(npc);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ApplyChoice(npc, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ApplyChoice(npc, 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ApplyChoice(npc, 3);
        }
    }

    void HandleQuestChoices(NPCData npc)
    {
        if (npc.quest.isCompleted)
            return;

        string requiredItem =
            GetQuestItemName(npc);

        if (npc.quest.isAccepted &&
            !npc.quest.isCompleted &&
            InventoryManager.Instance.HasItem(requiredItem) &&
            Input.GetKeyDown(KeyCode.Alpha1))
        {
            InventoryManager.Instance.RemoveItem(
                requiredItem
            );

            QuestManager.Instance.CompleteQuest(npc);

            dialogueText.text =
                npc.npcName +
                ":\nThank you for finding my " +
                requiredItem +
                "!\n\n" +
                "Friendship +" +
                npc.quest.friendshipReward;

            return;
        }

        if (!npc.quest.isAccepted &&
            Input.GetKeyDown(KeyCode.Alpha1))
        {
            QuestManager.Instance.AcceptQuest(npc);

            dialogueText.text =
                npc.npcName +
                ":\nThank you!\n\n" +
                "Quest Accepted:\n" +
                npc.quest.questName;
        }

        if (!npc.quest.isAccepted &&
            Input.GetKeyDown(KeyCode.Alpha2))
        {
            dialogueText.text =
                npc.npcName +
                ":\nAlright. Let me know later.";
        }
    }

    string GetQuestItemName(NPCData npc)
    {
        if (npc.npcName == "Alex")
            return "Notebook";

        if (npc.npcName == "Maya")
            return "Flower";

        if (npc.npcName == "Emma")
            return "Photo";

        return "";
    }

    void ApplyChoice(NPCData npc, int choice)
    {
        int friendshipChange =
            NPCDialogueDatabase.GetFriendshipChange(choice);

        npc.friendship += friendshipChange;

        npc.metPlayer = true;
        npc.choiceMade = true;

        npc.conversationStage++;

        SaveManager.SaveNPC(npc);

        Debug.Log(
            npc.npcName +
            " Stage = " +
            npc.conversationStage +
            " | Friendship = " +
            npc.friendship
        );

        string sign = friendshipChange >= 0 ? "+" : "";

        dialogueText.text =
            npc.npcName +
            ":\nConversation Complete!\n\n" +
            "Friendship " +
            sign +
            friendshipChange +
            "\nStage " +
            npc.conversationStage;
    }

    public void CloseDialogue()
    {
        isOpen = false;

        dialoguePanel.SetActive(false);

        PlayerMovement.canMove = true;
    }
}