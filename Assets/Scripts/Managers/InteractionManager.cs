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

        dialogueText.text =
            NPCDialogueDatabase.GetStageDialogue(npc);
    }

    void HandleChoices()
    {
        if (NPCInteraction.currentNPC == null)
            return;

        NPCData npc = NPCInteraction.currentNPC;

        // Quest dialogue after Stage 4
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

        // Accept Quest
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

        // Decline Quest
        if (!npc.quest.isAccepted &&
            Input.GetKeyDown(KeyCode.Alpha2))
        {
            dialogueText.text =
                npc.npcName +
                ":\nAlright. Let me know later.";
        }

        // TEMPORARY QUEST COMPLETE KEY
        if (npc.quest.isAccepted &&
            !npc.quest.isCompleted &&
            Input.GetKeyDown(KeyCode.Q))
        {
            QuestManager.Instance.CompleteQuest(npc);

            dialogueText.text =
                npc.npcName +
                ":\nYou found it!\n\n" +
                "Friendship +" +
                npc.quest.friendshipReward;
        }
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