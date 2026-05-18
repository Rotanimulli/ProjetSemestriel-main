using UnityEngine;

public class SceneModifier : MonoBehaviour
{

    [SerializeField] DoorOpening doorToOpen;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    private bool isActivated = false;

    private void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && passive != null)
            spriteRenderer.sprite = passive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivated)
            return;

        isActivated = true;

        doorToOpen.AddCounter();

        if (spriteRenderer != null && active != null)
            spriteRenderer.sprite = active;
    }

   
}