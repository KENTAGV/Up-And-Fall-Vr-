using UnityEngine;
using System.Collections;

public class ExhibicionTrigger : MonoBehaviour
{
    public GameObject objeto;
    public Light luz;

    // Ahora son AudioSource directamente
    public AudioSource sonidoEntrada;
    public AudioSource sonidoSalida;

    // Texto UI
    public GameObject textoUI;

    private Coroutine rutinaSalida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (rutinaSalida != null)
                StopCoroutine(rutinaSalida);

            ActivarExhibicion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rutinaSalida = StartCoroutine(DesactivarConDelay());
        }
    }

    void ActivarExhibicion()
    {
        objeto.SetActive(true);
        luz.enabled = true;

        // Activar texto
        if (textoUI != null)
            textoUI.SetActive(true);

        // Reproducir sonido
        if (sonidoEntrada != null)
            sonidoEntrada.Play();
    }

    IEnumerator DesactivarConDelay()
    {
        yield return new WaitForSeconds(5f);

        objeto.SetActive(false);
        luz.enabled = false;

        // Desactivar texto
        if (textoUI != null)
            textoUI.SetActive(false);

        // Reproducir sonido de salida
        if (sonidoSalida != null)
            sonidoSalida.Play();
    }
}