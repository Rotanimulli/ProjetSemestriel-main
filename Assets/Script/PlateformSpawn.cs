using UnityEngine;

public class PlateformSpawn : MonoBehaviour
{
    public Plateform plateformToSpawn;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (plateformToSpawn != null)
            {
                var plat = Instantiate(plateformToSpawn.gameObject);
                plat.transform.position = transform.position + Vector3.one * 1;
                
            }
        }
    }
}
