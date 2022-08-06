using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public bool IsThatRightKey;

    public GameObject KeyHint;

    void Start()
    {
        KeyHint.SetActive(false);
    }

    void OnMouseEnter()
    {
        if (GameManager.Instance.Stage != 2) return;

        if (IsThatRightKey)
        {
            TextBoxManager.Instance.ShowBox("O, to ten klucz");
            KeyHint.SetActive(true);
        }
        else
        {
            TextBoxManager.Instance.ShowBox("To nie jest ten klucz");
        }
    }

    void OnMouseExit()
    {
        if (GameManager.Instance.Stage != 2) return;

        if (IsThatRightKey)
        {
            KeyHint.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.Stage != 2) return;

        if (IsThatRightKey)
        {
            HintsManager.Instance.UpdateHints(3);
            Destroy(gameObject);
        }
    }
}