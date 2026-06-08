using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public static bool canMove = true;

    void Update()
    {
        if (!canMove)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.Translate(movement * speed * Time.deltaTime);
    }
}