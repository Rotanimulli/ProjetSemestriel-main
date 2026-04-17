using UnityEngine;
public class fragment : MonoBehaviour
{
    public Plateform platformToTransferToPlayer;

    private bool isUsed = false;
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherPlateformSpawn = other.GetComponent<PlateformSpawn>();
        if (otherPlateformSpawn != null)
        {
            otherPlateformSpawn.plateformToSpawn = platformToTransferToPlayer;
        }
    }
   
    public void Restore()
    {
        gameObject.SetActive(true);
        isUsed = false;
    }
}