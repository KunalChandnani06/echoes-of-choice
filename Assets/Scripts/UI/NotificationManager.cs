using UnityEngine;
using TMPro;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance;

    public TMP_Text notificationText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowNotification(string message)
    {
        StopAllCoroutines();

        StartCoroutine(
            ShowRoutine(message)
        );
    }

    IEnumerator ShowRoutine(string message)
    {
        notificationText.gameObject.SetActive(true);

        notificationText.text = message;

        yield return new WaitForSeconds(2f);

        notificationText.gameObject.SetActive(false);
    }
}