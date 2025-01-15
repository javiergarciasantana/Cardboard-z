using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInterface : MonoBehaviour
{
    public int lives = 3; // Vidas del jugador
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public string gameOverSceneName = "Game Over"; // Nombre de la escena de Game Over
    public float invulnerabilityTime = 1.0f; // Tiempo de invulnerabilidad (en segundos)
    private bool isInvulnerable = false; // Estado de invulnerabilidad
    public ParticleSystem bloodEffect; // Prefab de sangre asignado desde el inspector

    public void TakeDamage()
    {
        if (!isInvulnerable) // Solo recibe daño si no es invulnerable
        {
            bloodEffect.transform.position = transform.position;
            lives--;
            Debug.Log("Lives remaining: " + lives);
            UpdateLives(lives);
            // Activa el efecto de sangre
            if (bloodEffect != null)
            {
                bloodEffect.Play();
            }

            // Si las vidas llegan a 0, el jugador muere
            if (lives <= 0)
            {
                Debug.Log("Player is dead! Loading Game Over scene...");
                SceneManager.LoadScene(gameOverSceneName);
            }

            // Activa el estado de invulnerabilidad
            StartCoroutine(InvulnerabilityCooldown());
        }
    }

    private System.Collections.IEnumerator InvulnerabilityCooldown()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime); // Espera el tiempo de invulnerabilidad
        isInvulnerable = false; // Desactiva la invulnerabilidad
    }
    public void UpdateLives(int lives)
    {
        if (lives == 2) {
            Destroy(life3);
        } else if (lives == 1) {
            Destroy(life2);
        } else if (lives == 0) {
            Destroy(life1);
        }
    }
}


