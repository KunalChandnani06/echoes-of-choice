using UnityEngine;

public class NotebookQuestItem : MonoBehaviour
{
    private bool playerNearby = false;

    private void Update()
    {
        if (!playerNearby)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            NPCData[] npcs =
                FindObjectsByType<NPCData>(
                    FindObjectsSortMode.None
                );

            bool questAccepted = false;

            foreach (NPCData npc in npcs)
            {
                if (npc.quest.isAccepted &&
                    !npc.quest.isCompleted)
                {
                    questAccepted = true;
                    break;
                }
            }

            if (!questAccepted)
            {
                Debug.Log(
                    "Alex hasn't asked you to find this yet."
                );
                return;
            }

            InventoryManager.Instance.AddItem(
                "Notebook"
            );

            Debug.Log(
                "Notebook collected"
            );

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            Debug.Log(
                "Press E to collect Notebook"
            );
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}