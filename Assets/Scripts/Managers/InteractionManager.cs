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
        isOpen = true;

        dialoguePanel.SetActive(true);

        PlayerMovement.canMove = false;

        if (!NPCMemory.metAlex)
        {
            dialogueText.text =
                "Alex:\nHey, nice to meet you.\n\n" +
                "1 - Nice to meet you too.\n" +
                "2 - Ignore Alex.\n" +
                "3 - Tell a joke.";
        }
        else
        {
            string relationship =
    RelationshipManager.GetRelationshipLevel(
        FriendshipManager.friendship
    );

            if (relationship == "Dislikes You")
            {
                dialogueText.text =
                    "Alex:\nI'd rather be alone right now.";
            }
            else if (relationship == "Acquaintance")
            {
                dialogueText.text =
                    "Alex:\nGood to see you again.\n" +
                    "Relationship: Acquaintance";
            }
            else if (relationship == "Friend")
            {
                dialogueText.text =
                    "Alex:\nHey friend! Nice seeing you.\n" +
                    "Relationship: Friend";
            }
            else
            {
                dialogueText.text =
                    "Alex:\nI've been waiting for you!\n" +
                    "Relationship: Close Friend";
            }
        }
    }

    void HandleChoices()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NPCMemory.metAlex = true;
            FriendshipManager.friendship += 5;

            dialogueText.text =
                "Alex:\nGlad to hear that!\n\nFriendship +5";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            NPCMemory.metAlex = true;
            FriendshipManager.friendship -= 5;

            dialogueText.text =
                "Alex:\nOh... okay.\n\nFriendship -5";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NPCMemory.metAlex = true;
            FriendshipManager.friendship += 2;

            dialogueText.text =
                "Alex:\nHaha, that's funny.\n\nFriendship +2";
        }
    }

    public void CloseDialogue()
    {
        isOpen = false;

        dialoguePanel.SetActive(false);

        PlayerMovement.canMove = true;
    }
}