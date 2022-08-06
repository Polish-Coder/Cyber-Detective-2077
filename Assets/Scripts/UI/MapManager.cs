using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    CanvasGroup canvasGroup;
    Image room;

    bool isShowing;

    bool alphaUp;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        canvasGroup = GetComponent<CanvasGroup>();
        room = transform.GetChild(0).GetComponent<Image>();
        canvasGroup.alpha = 0;
        isShowing = false;
    }

    void Update()
    {
        if (!isShowing) return;

        if (room.color.a == 0)
        {
            alphaUp = true;
        }
        else if (room.color.a == 0.04f)
        {
            alphaUp = false;
        }

        if (alphaUp)
        {
            Color color = room.color;

            color.a = Mathf.Lerp(color.a, 0.04f, 5 * Time.deltaTime);

            if (color.a >= 0.035f)
            {
                color.a = 0.04f;
            }

            room.color = color;
        }
        else
        {
            Color color = room.color;

            color.a = Mathf.Lerp(color.a, 0, 5 * Time.deltaTime);

            if (color.a <= 0.005f)
            {
                color.a = 0;
            }

            room.color = color;
        }
    }

    public void Show()
    {
        StartCoroutine(ShowMap());
    }

    IEnumerator ShowMap()
    {
        canvasGroup.alpha = 1;
        isShowing = true;

        yield return new WaitForSeconds(5);

        isShowing = false;
        canvasGroup.alpha = 0;

        yield break;
    }
}