using UnityEngine;
using UnityEngine.UI;

public class LevelCompalte : MonoBehaviour
{
    [SerializeField] private Button _level1;
    [SerializeField] private Button _level2;
    [SerializeField] private GameObject[] _lockImages;

    private void Awake()
    {
        switch (PlayerPrefs.GetInt("levelComplate"))
        {
            case 1:
                _level1.interactable = true;
                _lockImages[0].SetActive(false); break;
            case 2:
                _level2.interactable = true;
                _level1.interactable = true;
                _lockImages[0].SetActive(false);
                _lockImages[1].SetActive(false); break;
        }
    }

}
