using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointsPerCoin = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the coin!");
            other.GetComponent<PlayerScore>().AddScore(pointsPerCoin);

            // Debug לפני שמוחקים את המטבע
            Debug.Log("Destroying coin!");
            Destroy(gameObject);
        }
    }
}
