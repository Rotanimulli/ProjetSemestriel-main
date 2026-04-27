using System.Runtime.CompilerServices;
using UnityEngine;

public class EnnemiMove : MonoBehaviour
{
    public Transform positionA, positionB;
    public int Speed;
    Vector2 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = positionB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, positionA.position) < .1f) targetPosition = positionB.position;

        if (Vector2.Distance(transform.position, positionB.position) < .1f) targetPosition = positionA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}