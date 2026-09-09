using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Header("캐릭터 이동 속도")] private float _moveSpeed;
    [SerializeField] [Header("점프력")] private float _jumpPower;
    [SerializeField] [Header("하강시 중력 값")] private float _downSpeed;
    public Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private bool _isJumping;
    private float _jumpTimer;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Time.deltaTime * _moveSpeed * Vector3.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * _moveSpeed * Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }

        if (_isJumping)
        {
            _jumpTimer += Time.deltaTime;
            if (_rigidbody.linearVelocityY < 0)
            {
                _isJumping = false;
                _rigidbody.gravityScale = _downSpeed;
            }
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(_jumpPower * Vector2.up, ForceMode2D.Impulse);
        _isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _rigidbody.gravityScale = 1f;
            _jumpTimer = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}