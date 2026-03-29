using UnityEngine;

public class SalaTrigger : MonoBehaviour
{
    public GameObject sala;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sala.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sala.SetActive(false);
        }
    }
}
