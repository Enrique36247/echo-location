using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Victoria! Has encontrado la salida.");
            WinGame();
        }
    }

    void WinGame()
    {
        // Cargamos la escena de victoria
        SceneManager.LoadScene("VictoryScene");
    }
}