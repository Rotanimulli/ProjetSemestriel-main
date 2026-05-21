using UnityEngine;

public class Pylone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var cineManager = CinematiqueManager.instance;
        cineManager.AddCounter();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
