using System.Collections;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(HitStop(0.2f));
        }
    }

    IEnumerator HitStop(float time)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1f;
    }
}
