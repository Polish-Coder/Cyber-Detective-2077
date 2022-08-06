using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject DoorsHint;

    public Transform DoorsLeft;
    public Transform DoorsRight;

    public Vector3 LeftPos;
    public Vector3 RightPos;

    bool open;
    bool isOpen;

    void Start()
    {
        DoorsHint.SetActive(false);
    }

    void Update()
    {
        if (!open) return;

        DoorsLeft.position = Vector3.Lerp(DoorsLeft.position, LeftPos, Time.deltaTime);
        DoorsRight.position = Vector3.Lerp(DoorsRight.position, RightPos, Time.deltaTime);

        if (Vector3.Distance(DoorsLeft.position, LeftPos) <= 0.01f)
        {
            DoorsLeft.position = LeftPos;
            DoorsRight.position = RightPos;
            isOpen = true;
        }
    }

    void OnMouseEnter()
    {
        if (GameManager.Instance.Stage != 3 && isOpen == false) return;

        DoorsHint.SetActive(true);
    }

    void OnMouseExit()
    {
        if (GameManager.Instance.Stage != 3) return;

        DoorsHint.SetActive(false);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.Stage != 3 && isOpen == false) return;

        open = true;

        HintsManager.Instance.UpdateHints(4);
    }
}