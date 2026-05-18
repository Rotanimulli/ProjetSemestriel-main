using System.Collections;

using UnityEngine;

public class Death : MonoBehaviour

{

    Vector2 CheckPointPosition;

    Rigidbody2D playerRb;

    [SerializeField] private Animator Cory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()

    {

        playerRb = GetComponent<Rigidbody2D>();

    }

    private void Start()

    {

        CheckPointPosition = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.CompareTag("Obstacle"))

        {

            Die();
           
            
        }

    }

    public void updateCheckPoint(Vector2 pos)
    {
        CheckPointPosition = pos;
    }

    void Die()

    {
        Cory.SetBool("IsDead", true);
        StartCoroutine(Respawn(0.5f));
        
    }

    IEnumerator Respawn(float duration)

    {
        playerRb.simulated = false;
        playerRb.linearVelocity = new Vector2(0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = CheckPointPosition;
        playerRb.simulated = true;
        Cory.SetBool("IsDead", false);

    }

   

}

