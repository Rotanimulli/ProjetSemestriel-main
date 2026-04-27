using System.Collections;

using UnityEngine;

public class Death : MonoBehaviour

{

    Vector2 startPosition;

    Rigidbody2D playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()

    {

        playerRb = GetComponent<Rigidbody2D>();

    }

    private void Start()

    {

        startPosition = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.CompareTag("Obstacle"))

        {

            Die();

        }

    }

    void Die()

    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)

    {

        playerRb.simulated = false;
        playerRb.linearVelocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = startPosition;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;

    }

}

