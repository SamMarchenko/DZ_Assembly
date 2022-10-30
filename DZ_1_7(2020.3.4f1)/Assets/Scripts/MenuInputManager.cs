using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInputManager : BaseInputManager
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(() => PlayLevel(1));
        _exitButton.onClick.AddListener(ExitGame);
    }
    
    private void ExitGame()
    {
#if UNITY_ANDROID
        Debug.Log("Exit");
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPaused = true;
#endif
    }
}