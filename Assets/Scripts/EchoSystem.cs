using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class EchoSystem : MonoBehaviour
{
    [Header("Configuración de la Onda")]
    public Light echoLight;
    public float echoDuration = 1f;    // Cuánto tarda la intensidad en llegar a 0
    public float maxIntensity = 25000f; 
    public float maxRange = 35f; 

    [Header("Audio")]
    public AudioSource echoSound;

    private bool canEcho = true; // Control de disparo

    void Start()
    {
        if (echoLight != null) 
        {
            echoLight.gameObject.SetActive(false);
        }
    }

    // Se activa con el botón de "Fire" del Input System
    public void OnFire()
    {
        // Solo permite disparar si canEcho es verdadero
        if (canEcho)
        {
            if (echoSound != null) 
            {
                echoSound.Play();
            }

            StartCoroutine(PerformEcho());
        }
    }

    IEnumerator PerformEcho()
    {
        // Bloqueamos el siguiente disparo de inmediato
        canEcho = false;
        echoLight.gameObject.SetActive(true);
        
        float timer = 0f;

        while (timer < echoDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / echoDuration;
            
            // La luz se expande y se apaga
            echoLight.range = Mathf.Lerp(0, maxRange, progress);
            echoLight.intensity = Mathf.Lerp(maxIntensity, 0, progress);
            
            yield return null;
        }

        // Apagamos la luz físicamente
        echoLight.gameObject.SetActive(false);
        
        // IMPORTANTE: Hasta que no termina el ciclo anterior, no habilitamos el siguiente
        canEcho = true; 
    }
}