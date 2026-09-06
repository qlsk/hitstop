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
            StartCoroutine(HitStopCoroutine(0.2f));
        }
    }

    private IEnumerator HitStopCoroutine(float time)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1f;
    }

    public void HitStop(float time)
    {
        StartCoroutine(HitStopCoroutine(time));
    }
}
