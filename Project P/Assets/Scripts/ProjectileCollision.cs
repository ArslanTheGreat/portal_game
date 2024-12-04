using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to load scenes

public class PlayerCollisionHandler : MonoBehaviour
{
    public string projectileTag = "Projectile"; // Tag to identify projectiles
    public string gameOverScene = "GameOverScene"; // Scene to load on game over

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag(projectileTag))
        {
            Debug.Log("Player hit by a projectile. Game over!");
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger detected with: {other.gameObject.name}");

        if (other.CompareTag(projectileTag))
        {
            Debug.Log("Player hit by a projectile (trigger). Game over!");
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Ending the game...");
        // Ensure the scene exists in Build Settings

        // use LoadSceneAsync instead of LoadScene to avoid performance issues
        SceneManager.LoadSceneAsync(gameOverScene, LoadSceneMode.Single);
      
    }
}


