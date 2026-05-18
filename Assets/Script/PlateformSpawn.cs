using UnityEngine;

public class PlateformSpawn : MonoBehaviour
{
    public Plateform plateformToSpawn;
    [SerializeField] private Animator Cory;
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
                Cory.SetTrigger("spawnPlatformAction");
                var plat = Instantiate(plateformToSpawn.gameObject);
                plat.transform.position = transform.position + Vector3.one * 1;
                plateformToSpawn = null;
                
            }
        }
    }
}
