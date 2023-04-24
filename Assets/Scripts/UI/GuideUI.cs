using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideUI : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            GameManager.Instance.SetGameStart(true);
            gameObject.SetActive(false);
        }
    }
}
