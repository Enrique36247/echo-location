using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        // En los menús necesitamos ver el ratón y que no esté bloqueado
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        // Carga la escena del juego (asegúrate de que el nombre coincida)
        // O puedes usar el índice: SceneManager.LoadScene(1);
        SceneManager.LoadScene("SampleScene"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}