using System.Collections;
using UnityEngine;
public class fragment : MonoBehaviour
{
    public Plateform platformToTransferToPlayer;

    private bool isUsed = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherPlateformSpawn = other.GetComponent<PlateformSpawn>();
        if (otherPlateformSpawn != null)
        {
            otherPlateformSpawn.plateformToSpawn = platformToTransferToPlayer;
            StartCoroutine(DisappearAndRespawn());
        }
    }

    private IEnumerator DisappearAndRespawn()
    {
        isUsed = true;

        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (col != null)
            col.enabled = false;

        yield return new WaitForSeconds(5);

        if (spriteRenderer != null)
            spriteRenderer.enabled = true;

        if (col != null)
            col.enabled = true;
    }
   
    public void Restore()
    {
        gameObject.SetActive(true);
        isUsed = false;
    }
}