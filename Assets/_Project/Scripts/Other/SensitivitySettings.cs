using System;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySettings : MonoBehaviour
{
    [SerializeField] private Slider _sensitivitySlider;
    [SerializeField] private Play _settingsPlayMode;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Button _closeSettingsButton;

    public static event Action OnGetSensitivity;

    private void Start()
    {
        _closeSettingsButton.onClick.AddListener(CloseSettings);
        _sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity", 3);
    }

    private void Update()
    {
        OpenSettings();
    }

    private void OpenSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _settingsPanel.SetActive(true);
            _settingsPlayMode.StopGame();
        }
    }

    private void CloseSettings()
    {
        _settingsPlayMode.PlayGame();
        PlayerPrefs.SetFloat("sensitivity", _sensitivitySlider.value);
        Debug.Log($"Button {PlayerPrefs.GetFloat("sensitivity", 3)}");
        OnGetSensitivity?.Invoke();
        _settingsPanel.SetActive(false);
    }
}
