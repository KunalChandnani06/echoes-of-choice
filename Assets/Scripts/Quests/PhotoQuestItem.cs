using UnityEngine;

public class PhotoQuestItem : MonoBehaviour
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

            bool emmaQuestAccepted = false;

            foreach (NPCData npc in npcs)
            {
                if (npc.npcName == "Emma" &&
                    npc.quest.isAccepted &&
                    !npc.quest.isCompleted)
                {
                    emmaQuestAccepted = true;
                    break;
                }
            }

            if (!emmaQuestAccepted)
            {
                NotificationManager.Instance.ShowNotification(
                    "Emma hasn't asked for this yet."
                );

                return;
            }

            InventoryManager.Instance.AddItem(
                "Photo"
            );

            NotificationManager.Instance.ShowNotification(
                "Photo Added"
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