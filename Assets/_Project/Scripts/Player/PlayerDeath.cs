using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private bool _isCanDie;
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private GameObject _restartUI;
    [SerializeField] private Play _gameManager;
    [SerializeField] private GameObject _fire;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            LoaderScenes.RestartScene();
        }
    }

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
        {
            _restartUI.SetActive(true);
            _gameManager.StopGame();
        }
    }

    public void Burn()
    {
        _fire.SetActive(true);
    }
}
