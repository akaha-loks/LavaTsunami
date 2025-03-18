using TMPro;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTimer;
    [SerializeField] private float _timer;
    private float _timerRecord;
    private Coroutine _timerCoroutine;
    private int _currentLevel;

    private void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("levelCount", 1);
        _timerRecord = PlayerPrefs.GetFloat($"BestTime_Level{_currentLevel}", float.MaxValue);
        _timerCoroutine = StartCoroutine(UpdateTimer());
        Finish.Finished += OnFinish;
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            _timer += Time.deltaTime;
            _textTimer.text = _timer.ToString("F2");
            yield return null;
        }
    }

    private void OnFinish()
    {
        if (_timer < _timerRecord)
        {
            _timerRecord = _timer;
            PlayerPrefs.SetFloat($"BestTime_Level{_currentLevel}", _timerRecord);
            PlayerPrefs.Save();
        }

        StopCoroutine(_timerCoroutine);
        Finish.SetTimes(_timer);
    }

    private void OnDisable()
    {
        Finish.Finished -= OnFinish;
    }
}
