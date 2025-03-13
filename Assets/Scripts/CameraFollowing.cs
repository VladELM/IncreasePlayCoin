using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth;

    private float _zValue;

    private void Start()
    {
        _zValue = transform.position.z;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _smooth);
        transform.position = new Vector3(transform.position.x, transform.position.y, _zValue);
    }
}
