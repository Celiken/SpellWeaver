using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameStarted;

    private void Awake()
    {
        Instance = this;
        isGameStarted = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Loader.Load(Loader.Scene.MainMenu);
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public void SetGameStart(bool start)
    {
        isGameStarted = start;
    }
}
