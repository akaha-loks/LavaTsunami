using System.Collections;
using UnityEngine;

public class LavaRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _rotationDuration = 2.0f;

    private void Start()
    {
        StartCoroutine(RotateCube());
    }
    private IEnumerator RotateCube()
    {
        while (true)
        {
            float elapsedTime = 0f;
            float currentRotateSpeed = _rotateSpeed;

            while (elapsedTime < _rotationDuration)
            {
                transform.Rotate(currentRotateSpeed * Time.deltaTime, 0, 0);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _rotateSpeed = -_rotateSpeed; // Reverse the rotation direction
        }
    }
}
