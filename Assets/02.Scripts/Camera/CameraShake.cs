using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _shakePower;
    [SerializeField] private float _shakeRepeatRate;
    [SerializeField] private float _shakeDuration;
    private bool _isShaking = false;
    private Vector3 _cameraPos;

    private void Start()
    {
        _cameraPos = _mainCamera.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shake();
        }
    }

    public void Shake()
    {
        InvokeRepeating("ShakeStart", 0f, _shakeRepeatRate);
        Invoke("CancelInvokeShake", _shakeDuration);
    }
    
    private void ShakeStart()
    {
        Vector2 shakePos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _mainCamera.transform.position += _shakePower * (Vector3)shakePos;
    }

    private void CancelInvokeShake()
    {
        CancelInvoke("ShakeStart");
        _mainCamera.transform.position = _cameraPos;
    }
}