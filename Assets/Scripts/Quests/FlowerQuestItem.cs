using UnityEngine;

public class FlowerQuestItem : MonoBehaviour
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

            bool mayaQuestAccepted = false;

            foreach (NPCData npc in npcs)
            {
                if (npc.npcName == "Maya" &&
                    npc.quest.isAccepted &&
                    !npc.quest.isCompleted)
                {
                    mayaQuestAccepted = true;
                    break;
                }
            }

            if (!mayaQuestAccepted)
            {
                NotificationManager.Instance.ShowNotification(
                    "Maya hasn't asked for this yet."
                );

                return;
            }

            InventoryManager.Instance.AddItem(
                "Flower"
            );

            NotificationManager.Instance.ShowNotification(
                "Flower Added"
            );

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
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