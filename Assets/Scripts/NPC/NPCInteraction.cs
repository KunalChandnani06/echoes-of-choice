using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public static bool playerNearNPC = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearNPC = true;
            Debug.Log("Player entered Alex's zone");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearNPC = false;

            InteractionManager.Instance.CloseDialogue();

            Debug.Log("Player left Alex's zone");
        }
    }
}