using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsPaused { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeGame();
    }
    private void InitializeGame()
    {
        IsPaused = false;
        
    }
    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        
    }
    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
