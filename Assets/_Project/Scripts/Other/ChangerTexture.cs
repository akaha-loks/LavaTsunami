using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerTexture : MonoBehaviour
{
    private Renderer objectRenderer;
    [SerializeField] private Texture[] textures;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null && textures.Length > 0)
        {
            // Если используешь стандартный шейдер в URP/HDRP, попробуй _BaseMap
            objectRenderer.material = new Material(objectRenderer.material);
            objectRenderer.material.SetTexture("_BaseMap", textures[Random.Range(0, textures.Length)]);
        }
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
#endif
}
