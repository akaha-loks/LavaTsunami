using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
    private static ContinueAudio instance = null;
    [SerializeField] private GameObject _music;
    private bool _isOff = false;

    public static ContinueAudio Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("MusicOff")  == 0 && !_isOff) 
            _music.SetActive(true);
        if(PlayerPrefs.GetInt("MusicOff") == 1)
            _music.SetActive(false);
    }
}