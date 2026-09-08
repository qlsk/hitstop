using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Toggle hitStopToggle;
    public Slider hitStopSlider;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(HitStopCoroutine(0.2f));
        }
    }

    private IEnumerator HitStopCoroutine(float time)
    {
        Time.timeScale = hitStopSlider.value;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1f;
    }

    public void HitStop(float time)
    {
        if (hitStopToggle.isOn)
        {
            StartCoroutine(HitStopCoroutine(time));
        }
    }
}