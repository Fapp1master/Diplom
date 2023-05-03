using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimControl : MonoBehaviour
{
    public GameObject InputCanvas;
    private void Start()
    {
        CanvasSetActive();
        Invoke("animSetActive", 18.0f);

    }

    private void animSetActive()
    {
        gameObject.SetActive(false);
        InputCanvas.SetActive(true);
    }

    private void CanvasSetActive()
    {
        InputCanvas.SetActive(false);
    }
}
