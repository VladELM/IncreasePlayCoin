using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private LayerMask _layerMask;


    private float _checkRadius;
    void Start()
    {
        _checkRadius = _groundCheck.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundTouchCheck())
            _playerRB.AddForce(Vector2.up * _jumpForce);
        //_playerRB.velocity = new Vector2(_playerRB.velocity.x, _jumpForce);
    }

    public bool GroundTouchCheck()
    {
        return Physics2D.OverlapCircle(_groundCheck.transform.position, _checkRadius, _layerMask);
    }
}
