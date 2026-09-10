using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField][Header("캐릭터 이동 속도")] private float _moveSpeed;
    [SerializeField][Header("점프력")] private float _jumpPower;
    [SerializeField][Header("하강시 중력 값")] private float _downSpeed;
    [SerializeField][Header("최대 점프 높이")] private float _maxJumpHeight;
    [SerializeField][Header("초기 점프")] private float _startJumpPower;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private bool _isJumping;
    private float _jumpStartPositionY;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.C) && _isGrounded)
        {
            // 시작 Y 위치 저장
            _jumpStartPositionY = transform.position.y;
            // Impulse로 점프 시작
            _rigidbody.AddForce(_startJumpPower * Vector2.up, ForceMode2D.Impulse);
            // 점프 중
            _isJumping = true;
        }

        // 점프키를 누르고 있을 때 + 점프 중일 때 + 현재 점프한 거리가 점프 최대 거리보다 낮을 때
        if (Input.GetKey(KeyCode.C) && _isJumping && (transform.position.y - _jumpStartPositionY < _maxJumpHeight))
        {
            _rigidbody.AddForce(_jumpPower * Vector2.up, ForceMode2D.Force);
        }

        // 플레이어가 떨어질 때 (수직 속도가 음수가 될 때)
        if (_rigidbody.linearVelocityY < 0f)
        {
            _isJumping = false;
            // 중력 증가
            _rigidbody.gravityScale = _downSpeed;
        }

        // 점프 키를 땠을 때
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (_rigidbody.linearVelocityY > 0f)
            {
                // 올라가던 속도 감소
                _rigidbody.linearVelocity *= 0.2f;
            }
        }
    }

    // 땅과 접촉했을 때
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true; // 땅과 접촉 상태
            _rigidbody.gravityScale = 1f; // 중력 정상화
        }
    }

    // 땅에서 떨어졌을 때
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}