using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Header("캐릭터 이동 속도")] private float _moveSpeed;
    [SerializeField] [Header("점프력")] private float _jumpPower;
    public Rigidbody2D _rigidbody;
    private bool _isGrounded;

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
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
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