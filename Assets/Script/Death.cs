using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour

{

    Vector2 CheckPointPosition;

    Rigidbody2D playerRb;
    public GameObject DeathParticle;
    [SerializeField] private Animator Cory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()

    {

        playerRb = GetComponent<Rigidbody2D>();

    }

    private void Start()

    {

        //CheckPointPosition = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.CompareTag("Obstacle"))

        {
            
            Die();
           
            
        }

    }

    //public void updateCheckPoint(Vector2 pos)
   // {
        //CheckPointPosition = pos;
    //}

    void Die()

    {
        gameObject.transform.SetParent(null);

        Instantiate(DeathParticle, transform.position, Quaternion.identity);

        Cory.SetBool("IsDead", true);
        
        StartCoroutine(Respawn(1f));
        
    }

    IEnumerator Respawn(float duration)

    {
       
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cory.SetBool("IsDead", false);

    }

   

}

