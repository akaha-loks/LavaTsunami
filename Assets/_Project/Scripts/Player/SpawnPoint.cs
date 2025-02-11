using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Start()
    {
        SetSpawnPoint(transform);
    }

    public void SetSpawnPoint(Transform spawnPos)
    {
        PlayerPrefs.SetFloat("x", spawnPos.position.x);
        PlayerPrefs.SetFloat("y", spawnPos.position.y);
        PlayerPrefs.SetFloat("z", spawnPos.position.z);
    }

    public Vector3 GetSpawnPoint()
    {
        return new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpawnPoint"))
        {
            SetSpawnPoint(other.transform);
            Debug.Log(GetSpawnPoint());
        }
    }
}
