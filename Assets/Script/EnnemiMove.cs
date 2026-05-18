using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

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
        {
           

        }

        if (Vector2.Distance(transform.position, positionB.position) < .1f) targetPosition = positionA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(positionA.position, positionB.position);
    }
}