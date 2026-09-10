using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] [Header("캐릭터 이동 속도")] private float _moveSpeed;
    [SerializeField] [Header("점프력")] private float _jumpPower;
    [SerializeField] [Header("하강시 중력 값")] private float _downSpeed;
    [SerializeField] [Header("최대 점프 높이")] private float _maxJumpHeight;
    [SerializeField] [Header("초기 점프")] private float _startJumpPower;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private bool _isJumping;
    private bool _isJumpStart = false;
    private float _jumpTimer;
    private float _jumpStartPositionY;
    private float _tempJumpPower;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _tempJumpPower = _jumpPower;
    }

    private void Update()
    {
        // 왼쪽 이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Time.deltaTime * _moveSpeed * Vector3.left);
        }

        // 오른족 이동
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * _moveSpeed * Vector3.right);
        }

        // 점프
        if (Input.GetKey(KeyCode.Space) && transform.position.y - _jumpStartPositionY < _maxJumpHeight)
        {
            // 점프 처음 시작할 때
            if (!_isJumpStart)
            {
                _jumpStartPositionY = transform.position.y;
                // _rigidbody.AddForce(_startJumpPower * Time.deltaTime * Vector2.up, ForceMode2D.Impulse);
                _isJumpStart = true;
            }
            Jump();
        }

        // 점프 중일 때
        if (_isJumping)
        {
            // 점프 타이머 증가
            // _jumpTimer += Time.deltaTime;
            // 점프 파워 줄어 듦
            // _jumpPower = Mathf.Lerp(_jumpPower, 0, Time.deltaTime);
            // 플레이어가 떨어질 때 (수직 속도가 음수가 될 때)
            if (_rigidbody.linearVelocityY < 3f)
            {
                _isJumping = false;
                _rigidbody.gravityScale = _downSpeed;
            }
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(_jumpPower * Vector2.up, ForceMode2D.Force);
        _isJumping = true;
    }

    // 땅과 접촉했을 때
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isJumpStart = false;
            _isGrounded = true;
            _jumpPower = _tempJumpPower; // 점프력 정상화
            _rigidbody.gravityScale = 1f; // 중력 정상화
            // _jumpTimer = 0; // 점프 타이머 초기화
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