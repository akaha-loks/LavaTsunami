using UnityEngine;

public class LavaDanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _toActiveObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var obj in _toActiveObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var obj in _toActiveObjects)
            {
                obj.SetActive(false);
            }
        }
    }
}
