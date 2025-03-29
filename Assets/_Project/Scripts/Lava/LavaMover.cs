using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class LavaMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;

    private void Start()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z - 75);
    }

    private void Update()
    {
        Vector3 moveDirection = transform.forward * _speed * Time.deltaTime;
        transform.position += moveDirection;
        transform.position = new Vector3(_player.position.x, transform.position.y, transform.position.z);
    }
}
