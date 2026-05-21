using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Plateform
{
    public float speed;
    public Rigidbody2D rb;
    public float lifeTime = 0f;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var dir = other.gameObject.GetComponent<CharMovement>().lastDir;
            transform.Translate(Vector3.right * speed*dir * Time.deltaTime);
            other.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
           other.gameObject.transform.SetParent(null);

        }
    }
    void Update()
    {
        
    }
}

// position
// original position

// if (position.y != original position.y)
// {
//      posittion.y = por 
// }
