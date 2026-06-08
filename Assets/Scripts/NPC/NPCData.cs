using UnityEngine;

public class NPCData : MonoBehaviour
{
    public string npcName = "Alex";

    [Header("Personality")]
    public string personalityType = "Friendly";

    [Header("Relationship")]
    public int friendship = 0;

    public bool metPlayer = false;

    public bool choiceMade = false;

    [Header("Conversation Progress")]
    public int conversationStage = 0;

    private void Start()
    {
        Debug.Log(
            npcName +
            " | Personality: " +
            personalityType +
            " | Friendship: " +
            friendship +
            " | Stage: " +
            conversationStage
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(
                npcName +
                " Current Stage = " +
                conversationStage
            );
        }
    }
}