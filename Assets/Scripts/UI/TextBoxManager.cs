using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    public static TextBoxManager Instance;

    RectTransform rectTransform;
    TMP_Text boxText;

    bool open = false;
    bool close = false;

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

        rectTransform = GetComponent<RectTransform>();
        boxText = transform.GetChild(0).GetComponent<TMP_Text>();

        rectTransform.sizeDelta = new Vector2(0, 75);
        boxText.text = "";
        boxText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (open)
        {
            float sizeX = Mathf.Lerp(rectTransform.sizeDelta.x, 800, 3 * Time.deltaTime);

            if (sizeX >= 790)
            {
                sizeX = 800;
                open = false;
            }

            rectTransform.sizeDelta = new Vector2(sizeX, rectTransform.sizeDelta.y);
        }

        if (close)
        {
            float sizeX = Mathf.Lerp(rectTransform.sizeDelta.x, 0, 3 * Time.deltaTime);

            if (sizeX <= 10)
            {
                sizeX = 0;
                close = false;
            }

            rectTransform.sizeDelta = new Vector2(sizeX, rectTransform.sizeDelta.y);
        }
    }

    public void ShowBox(string text)
    {
        boxText.text = text;
        StartCoroutine(CreateBox());
    }

    IEnumerator CreateBox()
    {
        rectTransform.sizeDelta = new Vector2(0, 75);

        open = true;

        while (rectTransform.sizeDelta.x != 800)
        {
            yield return null;
        }

        if (rectTransform.sizeDelta.x == 800)
        {
            boxText.gameObject.SetActive(true);

            yield return new WaitForSeconds(5);

            close = true;
            boxText.text = "";
            boxText.gameObject.SetActive(false);

            yield break;
        }
    }
}