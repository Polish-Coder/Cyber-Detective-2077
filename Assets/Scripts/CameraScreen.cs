using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : MonoBehaviour
{
    public GameObject CameraHint;

    void Start()
    {
        CameraHint.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        CameraHint.SetActive(true);
    }

    void OnMouseExit()
    {
        CameraHint.SetActive(false);
    }

    void OnMouseDown()
    {
        GameManager.Instance.OpenCamera();
        MapManager.Instance.Show();
    }
}