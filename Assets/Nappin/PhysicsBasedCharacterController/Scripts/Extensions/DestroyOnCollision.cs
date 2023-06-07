using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the collider
        if (other.CompareTag("Player"))
        {
            // Destroy the GameObject
            Destroy(gameObject);
        }
    }
}
