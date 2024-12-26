using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int pointsPerObstacle = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit an obstacle!");
            PlayerScore playerScore = collision.gameObject.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddObstracles(pointsPerObstacle);
            }
        }
    }
}
