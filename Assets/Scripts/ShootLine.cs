using UnityEngine;

public class ShootLine : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject lineObjectPrefab;
    public float growthSpeed = 4.0f;
    public float maxHeight = 2.9f;

    private bool isShooting = false;

    void Update()
    {
        Shoot();
    }

    void SetPivot(Vector2 pivot)
    {
        SpriteRenderer spriteRenderer = lineObjectPrefab.GetComponent<SpriteRenderer>();
        Sprite sprite = Sprite.Create(spriteRenderer.sprite.texture, spriteRenderer.sprite.rect, pivot, spriteRenderer.sprite.pixelsPerUnit);
        spriteRenderer.sprite = sprite;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            SetPivot(new Vector2(2f, 0f));
            lineObjectPrefab.transform.position = new Vector2(playerTransform.position.x, -1.279f);
            lineObjectPrefab.transform.localScale = new Vector2(0.03f, 0f);
            lineObjectPrefab.SetActive(true);
            isShooting = true;
        }

        if (isShooting)
        {
            float newHeight = lineObjectPrefab.transform.localScale.y + growthSpeed * Time.deltaTime;
            lineObjectPrefab.transform.localScale = new Vector2(0.03f, newHeight);

            if (newHeight >= maxHeight)
            {
                isShooting = false;
                lineObjectPrefab.SetActive(false);
            }
        }
    }
}
