using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private bool _isCanDie;
    [SerializeField] private SpawnPoint _spawnPoint;

    public void Die()
    {
        if (_isCanDie)
        {
            transform.position = _spawnPoint.GetSpawnPoint();
        }
    }

    public void DieLava()
    {
        if (_isCanDie)
            LoaderScenes.RestartScene();
    }
}
