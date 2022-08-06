using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Stage;

    public static GameManager Instance;

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

        GameObject.Find("Canvas/Game Over Screen").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Canvas/Win Screen").GetComponent<CanvasGroup>().alpha = 0;
    }

    void Update()
    {
        if (GameObject.Find("Canvas/Win Screen").GetComponent<CanvasGroup>().alpha == 1)
        {
            Color baseColor = GameObject.Find("Canvas/Win Screen/Text").GetComponent<TMP_Text>().color;
            Color.RGBToHSV(baseColor, out float h, out _, out _);

            float hue = Mathf.Lerp(h, h + 0.5f, Time.deltaTime);

            if (hue == 360)
            {
                hue = 0;
            }

            Color color = Color.HSVToRGB(hue, 1, 1);

            GameObject.Find("Canvas/Win Screen/Text").GetComponent<TMP_Text>().color = color;
        }
    }

    public void OpenCamera()
    {
        HintsManager.Instance.UpdateHints(2);
        TextBoxManager.Instance.ShowBox("Zak³adnik znajduje siê w pokoju nr 5");
    }

    public void Win()
    {
        GameObject.Find("Canvas/Win Screen").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.Find("Canvas/Win Screen/Text").GetComponent<TMP_Text>().text = $"Wygra³eœ!\n<size=25>\n<color=white>Twój czas: {Timer.Instance.currentTime.ToString("0.00")}</color></size>";

        PlayerCamera.ShowMouse();
    }

    public void GameOver()
    {
        GameObject.Find("Canvas/Game Over Screen").GetComponent<CanvasGroup>().alpha = 1;

        PlayerCamera.ShowMouse();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}