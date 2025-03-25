using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    public int levelCount = 1;
    [SerializeField] private Transform[] levelPositions;
    [SerializeField] private Play play;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject[] lines;

    private void Awake()
    {
        levelCount = PlayerPrefs.GetInt("levelCount", 1);
        transform.position = levelPositions[levelCount - 1].position;

        switch (levelCount)
        {
            case 1:
                lines[1].SetActive(false);
                lines[2].SetActive(false);
                break;
            case 2:
                lines[0].SetActive(false);
                lines[2].SetActive(false);
                break;
            case 3:
                lines[0].SetActive(false);
                lines[1].SetActive(false);
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            play.StopGame();
            menuCanvas.SetActive(true);
        }
    }
}
