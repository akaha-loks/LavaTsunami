using System;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject resultUI;
    public static event Action Finished;

    private static float _lastTime;
    private static float _bestTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finish");
            resultUI.SetActive(true);
            Finished?.Invoke();
        }
    }
}
