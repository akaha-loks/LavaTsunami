using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class LavaMover : MonoBehaviour
{
    [SerializeField] private float _speed;
 
    private void Update()
    {
        Vector3 moveDirection = transform.forward * _speed * Time.deltaTime;
        transform.position += moveDirection;
    }
}
