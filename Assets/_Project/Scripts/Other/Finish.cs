using System;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject resultUI;
    public static event Action Finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finish");
            resultUI.SetActive(true);
            LevelComplate();
            Finished?.Invoke();
        }
    }

    private void LevelComplate()
    {
        if(PlayerPrefs.GetInt("levelCount") == 1 && PlayerPrefs.GetInt("levelComplate") == 0)
        {
            PlayerPrefs.SetInt("levelComplate", 1);
        }
        else if(PlayerPrefs.GetInt("levelCount") == 2)
        {
            PlayerPrefs.SetInt("levelComplate", 2);
        }
    }
}
