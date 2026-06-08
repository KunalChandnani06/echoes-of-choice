using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public static bool playerNearNPC = false;

    public static NPCData currentNPC;

    private NPCData npcData;

    private void Start()
    {
        npcData = GetComponent<NPCData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearNPC = true;

            currentNPC = npcData;

            Debug.Log("Player entered " + npcData.npcName + "'s zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearNPC = false;

            currentNPC = null;

            InteractionManager.Instance.CloseDialogue();

            Debug.Log("Player left " + npcData.npcName + "'s zone");
        }
    }
}