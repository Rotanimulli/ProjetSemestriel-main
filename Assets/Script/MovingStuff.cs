using UnityEngine;

public class MovingStuff : MonoBehaviour
{
    public Transform PositionA, PositionB;
    public int Speed;
    Vector2 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = PositionB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PositionA.position) < .1f) targetPosition = PositionB.position;

        if (Vector2.Distance(transform.position, PositionB.position) < .1f) targetPosition = PositionA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(PositionA.position, PositionB.position);
    }
}
