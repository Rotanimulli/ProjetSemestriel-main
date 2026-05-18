using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0,0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] GameObject particule;

    float counter;
    [SerializeField] bool isOnGround;

    private void Update()
    {
        counter += Time.deltaTime;
        
        if (isOnGround && Mathf.Abs(  playerRb.linearVelocity.x) > occurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }

        if (isOnGround == false)
        {
            particule.SetActive(false);
        } else
        {
            particule.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isOnGround = false;
        }
    }
}
