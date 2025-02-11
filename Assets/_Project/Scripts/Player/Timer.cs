using TMPro;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTimer;
    [SerializeField] private float _timer;

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        _timer = MathF.Round(_timer, 2);
        _textTimer.text = _timer.ToString();
    }
}
