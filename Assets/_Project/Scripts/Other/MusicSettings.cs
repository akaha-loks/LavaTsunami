using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void Start()
    {
        if (PlayerPrefs.GetInt("MusicOff") == 1)
        {
            _toggle.isOn = false;
        }
        else
        {
            _toggle.isOn = true;
        }
    }

    public void MusicChangeEnable()
    {
        if (_toggle.isOn)
        {
            PlayerPrefs.SetInt("MusicOff", 0);
        }
        else
        {
            PlayerPrefs.SetInt("MusicOff", 1);
        }

    }
}
