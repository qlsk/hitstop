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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHit playerHit = collision.gameObject.GetComponent<PlayerHit>();
            playerHit.HitStop(0.3f);
            Destroy(gameObject);
        }
    }
}
