using UnityEngine;
using System.Collections;

public class DestructibleTerrain : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Texture2D mainTexture;
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        //get components
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();

        // Get the texture from the sprite. We need a readable copy.
        mainTexture = spriteRenderer.sprite.texture;

        // Make a duplicate so we can modify it without changing the original asset
        Texture2D newTexture = new Texture2D(mainTexture.width, mainTexture.height);
        newTexture.SetPixels(mainTexture.GetPixels());
        newTexture.Apply();

        // Assign the new texture to a new sprite
        spriteRenderer.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));
        mainTexture = newTexture;

        // Ensure the collider matches the initial terrain
        UpdateCollider();
    }

    // Call this from your explosion script
    public void DestroyTerrain(Vector2 worldPos, float radius)
    {
        // Convert world position to local position
        Vector2 localPos = transform.InverseTransformPoint(worldPos);

        // Convert world position to pixel coordinates
        int pixelX = Mathf.RoundToInt(localPos.x * mainTexture.width / spriteRenderer.size.x + mainTexture.width / 2);
        int pixelY = Mathf.RoundToInt(localPos.y * mainTexture.height / spriteRenderer.size.y + mainTexture.height / 2);
        int pixelRadius = Mathf.RoundToInt(radius * mainTexture.width / spriteRenderer.size.x);

        // Get the pixels within the circle of the explosion
        Color[] pixels = mainTexture.GetPixels(pixelX - pixelRadius, pixelY - pixelRadius, pixelRadius * 2, pixelRadius * 2);

        // Set the pixels to be transparent
        for (int y = 0; y < pixels.Length; y++)
        {
            pixels[y] = Color.clear;
        }

        // Apply the modified pixels back to the texture
        mainTexture.SetPixels(pixelX - pixelRadius, pixelY - pixelRadius, pixelRadius * 2, pixelRadius * 2, pixels);
        mainTexture.Apply();

        // Update the collider to match the new terrain shape
        UpdateCollider();
    }

    private void UpdateCollider()
    {
        // Remove the existing collider to rebuild it
        Destroy(polygonCollider);
        polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
    }
}
