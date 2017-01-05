using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickExample : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject scorebon;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
        }
        if (isPaused) { 
            Time.timeScale = 0f;
        }
        if (!isPaused) { 
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        (scorebon.gameObject).SetActive(true);
    }

  
}