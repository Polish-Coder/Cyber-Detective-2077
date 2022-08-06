using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;

    public TMP_Text TimeText;

    public static Timer Instance;

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

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        TimeText.text = currentTime.ToString("0.00") + " s / 60 s";

        if (currentTime >= 60)
        {
            GameManager.Instance.GameOver();
        }
    }
}