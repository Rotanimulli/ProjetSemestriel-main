using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    Death gameController;
    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gameController.updateCheckPoint(transform.position);
            spriteRenderer.sprite = active;
        }
    }
}
