using UnityEngine;
using UnityEngine.UI;

public class LevelCompalte : MonoBehaviour
{
    [SerializeField] private Button _level1;
    [SerializeField] private Button _level2;

    private void Awake()
    {
        switch (PlayerPrefs.GetInt("levelComplate"))
        {
            case 1:
                _level1.interactable = true; break;
            case 2:
                _level2.interactable = true;
                _level1.interactable = true; break;
        }
    }

}
