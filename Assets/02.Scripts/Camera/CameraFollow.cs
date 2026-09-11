using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = Player.Instance.transform.position + new Vector3(0, 0, -1);
    }
}
