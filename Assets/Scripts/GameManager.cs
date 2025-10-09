using UnityEngine;

public class GameManager : MonoBehaviour
{

    int boxCollected = 0;

    public void CollectBox()
    {
        boxCollected++;
        Debug.Log("Boxes Collected: " + boxCollected);
    }
}
