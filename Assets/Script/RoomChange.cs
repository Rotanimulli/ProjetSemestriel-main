using UnityEngine;

public class RoomChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("coucou");
            SceneController.instance.NextScene();
        }
    }
}
