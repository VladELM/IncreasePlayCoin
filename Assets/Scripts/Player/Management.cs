using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _playerRB;
    private Vector2 _moveVector;
    private float _checkRadius;
    private string Horizontal = nameof(Horizontal);

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _checkRadius = _groundCheck.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        Walking();
        Jumping();
    }

    private void Walking()
    {
        //float currentVelocity = _playerRB.velocity.y;

        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //{
        //    _moveVector.x = Input.GetAxis(Horizontal);
        //    _playerRB.velocity = new Vector2(_moveVector.x * _speed, _playerRB.velocity.y);
        //}
        //else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    _playerRB.velocity = new Vector2(0, currentVelocity);
        //}

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float offset = Input.GetAxis(Horizontal);
            _playerRB.AddForce(transform.right * offset * _speed);
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundTouchChecking())
        {
            //_playerRB.velocity = new Vector2(_playerRB.velocity.x, _jumpForce);
            _playerRB.AddForce(Vector2.up * _jumpForce);
        }
    }

    private bool GroundTouchChecking()
    {
        return Physics2D.OverlapCircle(_groundCheck.transform.position, _checkRadius, _layerMask);
    }
}
