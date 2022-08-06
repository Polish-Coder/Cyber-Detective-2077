using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class HintsManager : MonoBehaviour
{
    CanvasGroup canvasGroup;

    TMP_Text currentTarget;

    bool updateAlpha = false;

    public static HintsManager Instance;

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
    }

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        currentTarget = transform.Find("Current Target Text").GetComponent<TMP_Text>();
        Init();
    }

    void Update()
    {
        if (updateAlpha == false) return;

        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, 3 * Time.deltaTime);

        if (canvasGroup.alpha >= 0.999f)
        {
            canvasGroup.alpha = 1;
            UpdateHints(1);
            updateAlpha = false;
        }
    }

    public void Init()
    {
        canvasGroup.alpha = 0;
        updateAlpha = true;
        UpdateHints(0);
    }

    public void UpdateHints(int stage)
    {
        GameManager.Instance.Stage = stage;

        switch (stage)
        {
            case 1:
                currentTarget.text = "1. Odnajdü pokÛj z kamerami";
                break;
            case 2:
                currentTarget.text = "<color=green>1. Odnajdü pokÛj z kamerami</color>\n2.Znajdü klucz do drzwi";
                break;
            case 3:
                currentTarget.text = "<color=green>1. Odnajdü pokÛj z kamerami\n2.Znajdü klucz do drzwi</color>\n3.Uwolnij zak≥adnika";
                break;
            case 4:
                currentTarget.text = "<color=green>1. Odnajdü pokÛj z kamerami\n2.Znajdü klucz do drzwi\n3.Uwolnij zak≥adnika</color>";
                break;
            default:
                currentTarget.text = "";
                break;
        }
    }
}