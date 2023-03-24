using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    public GameObject target;
    public Camera theCamera;
    public RectTransform indicator;

    void Update()
    {
        Vector3 screenPos = theCamera.WorldToViewportPoint(target.transform.position);
        bool onScreen = screenPos.z > 0 && screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1;
        if (onScreen)
        {
            indicator.gameObject.SetActive(false);
            return;
        }

        indicator.gameObject.SetActive(true);
        Vector2 screenCenter = new Vector2(Screen.width, Screen.height) / 2f;
        Vector2 targetScreenPos = new Vector2(screenPos.x * Screen.width, screenPos.y * Screen.height);
        Vector2 diff = targetScreenPos - screenCenter;

        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        indicator.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        float x = Mathf.Clamp(screenPos.x * Screen.width, 0 + indicator.rect.width / 2f, Screen.width - indicator.rect.width / 2f);
        float y = Mathf.Clamp(screenPos.y * Screen.height, 0 + indicator.rect.height / 2f, Screen.height - indicator.rect.height / 2f);
        indicator.anchoredPosition = new Vector3(x - Screen.width / 2f, y - Screen.height / 2f);
    }
}
