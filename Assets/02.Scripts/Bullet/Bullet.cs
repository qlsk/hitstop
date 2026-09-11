using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.left);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // TODO: HitStop
            PlayerHit playerHit = other.gameObject.GetComponent<PlayerHit>();
            playerHit.HitStop(0.3f);
            CameraShake cameraShake = other.gameObject.GetComponent<CameraShake>();
            cameraShake.Shake();
            Destroy(gameObject);
        }
    }
}