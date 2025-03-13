using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moving : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private float _speed;

    private string Horizontal = nameof(Horizontal);

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float currentVelocityY = _playerRigidbody.velocity.y;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float horizontalOffset = Input.GetAxis(Horizontal);
            _playerRigidbody.velocity = new Vector2(horizontalOffset * _speed, _playerRigidbody.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _playerRigidbody.velocity = new Vector2(0, currentVelocityY);
        }
    }
}
