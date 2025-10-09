using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionRadius = 5f;

    // This function is called when the projectile's collider hits something
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we hit is the terrain
        if (collision.gameObject.GetComponent<DestructibleTerrain>() != null)
        {
            // Get the DestructibleTerrain script from the object we hit
            DestructibleTerrain terrain = collision.gameObject.GetComponent<DestructibleTerrain>();

            // Get the point of collision
            Vector2 hitPoint = collision.contacts[0].point;

            // Call the DestroyTerrain method on the terrain script
            terrain.DestroyTerrain(hitPoint, explosionRadius);

            // Instantiate an explosion effect (optional)
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }
        }

        // Destroy the projectile itself after the collision
        Destroy(gameObject);
    }
}
