using System.Collections;
using UnityEngine;

public class TextureMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private MeshRenderer _meshRenderer;

    private Vector2 _meshOffset;

    private void Start()
    {
        _meshOffset = _meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        _meshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
    }

    private void Update()
    {
        var y = Mathf.Repeat(Time.time * _speed, 1);
        var offset = new Vector2(_meshOffset.x, y);

        _meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}
