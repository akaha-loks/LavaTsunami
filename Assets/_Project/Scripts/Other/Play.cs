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
}
