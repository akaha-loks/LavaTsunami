using UnityEngine;

public class SteveTutor : MonoBehaviour
{
    [SerializeField] private GameObject[] texts;
    [SerializeField] private Transform player;
    private void Start()
    {
        if (PlayerPrefs.GetString("lang") == "en")
        {
            texts[0].SetActive(true);
            texts[1].SetActive(false);
        }
        else
        {
            texts[0].SetActive(false);
            texts[1].SetActive(true);
        }
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // только по горизонтали

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation * Quaternion.Euler(-90, -90, 88.301f); // ѕоворот на 90 градусов по Y
        }
    }


}
