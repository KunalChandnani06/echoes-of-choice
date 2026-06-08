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

    void ApplyChoice(NPCData npc, int choice)
    {
        if (npc.conversationStage >= 4)
        {
            dialogueText.text =
                npc.npcName +
                ":\nWe've talked about everything for now.";
            return;
        }

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