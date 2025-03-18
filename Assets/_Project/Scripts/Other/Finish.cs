using System;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject resultUI;
    [SerializeField] private TextMeshProUGUI _textTime;
    [SerializeField] private TextMeshProUGUI _textTimeRecord;
    public static event Action Finished;

    private static float _lastTime;
    private static float _bestTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finish");
            resultUI.SetActive(true);
            _textTime.text = $"Текущее время: {_lastTime:F2}";
            _textTimeRecord.text = $"Рекорд: {_bestTime:F2}";
            Finished?.Invoke();
        }
    }

    public static void SetTimes(float lastTime)
    {
        _lastTime = lastTime;
    }

    public static void SetBestTime(float bestTime)
    {
        _bestTime = bestTime;
    }
}
