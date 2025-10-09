using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //test if the other object is the player
        if (other.CompareTag("Player"))
        {
            //find the GameManager and call the CollectBox method
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.CollectBox();
            }
            //destroy this box
            Destroy(gameObject);
        }

        



    }
}
