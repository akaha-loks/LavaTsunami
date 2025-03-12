using System.Collections;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    public int levelCount = 1;
    [SerializeField] private Transform[] levelPositions;
    [SerializeField] private Play play;
    [SerializeField] private GameObject menuCanvas;

    private void Awake()
    {
        levelCount = PlayerPrefs.GetInt("levelCount");
        transform.position = levelPositions[levelCount - 1].position;
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