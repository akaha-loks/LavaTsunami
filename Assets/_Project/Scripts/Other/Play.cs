using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject _chooseLvlCanvas;
    [SerializeField] private FirstPersonLook _look;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ChooseLevel");
            _chooseLvlCanvas.SetActive(true);
            StopGame();
        }
    }

    private void OnEnable()
    {
        Finish.Finished += StopGame;
    }
    private void OnDisable()
    {
        Finish.Finished -= StopGame;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _look.enabled = false;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _look.enabled = true;
    }

    #region Choosing Level
    public void ChooseLvl1()
    {
        PlayerPrefs.SetInt("levelCount", 1);
    }

    public void ChooseLvl2()
    {
        PlayerPrefs.SetInt("levelCount", 2);
    }

    public void ChooseLvl3()
    {
        PlayerPrefs.SetInt("levelCount", 3);
    }
    #endregion
}
