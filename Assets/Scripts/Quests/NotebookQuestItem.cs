using UnityEngine;

public class NotebookQuestItem : MonoBehaviour
{
    private bool playerNearby = false;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            NPCData[] npcs = FindObjectsOfType<NPCData>();

            foreach (NPCData npc in npcs)
            {
                if (npc.quest.isAccepted &&
                    !npc.quest.isCompleted)
                {
                    QuestManager.Instance.CompleteQuest(npc);

                    Debug.Log(
                        "Notebook returned to " +
                        npc.npcName
                    );
                }
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            Debug.Log(
                "Press E to pick up notebook"
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