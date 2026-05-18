using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Transform PositionA, PositionB;
    public int Speed;
    Vector2 targetPosition;

    [SerializeField]
    int pyloneNb;
    int currentPylone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = PositionB.position;
    }

    public void AddCounter()
    {
        currentPylone++;
        if (currentPylone >= pyloneNb)
        {
            StartCoroutine(Opening());
        }
    }

    // Update is called once per frame
    public IEnumerator Opening()
    {
        var t = 0f;
        while(t<1)
        {
            transform.position = Vector2.Lerp(PositionA.position, PositionB.position, t);
            t+= Time.deltaTime * Speed;
            yield return new WaitForEndOfFrame();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(PositionA.position, PositionB.position);
    }
}