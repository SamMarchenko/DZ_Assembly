using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayModeInputManager : BaseInputManager
{
    [SerializeField] private GameObject _androidControlButtons;
    [SerializeField] private OldPlayerController _playerController;
    [SerializeField] private Button _leftMoveButton;
    [SerializeField] private Button _rightMoveButton;
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _escapeButton;
    private bool _isAndroidBuild;

    private void Awake()
    {
       SelectControlType();
    }

    private void CheckBuildType()
    {
#if UNITY_ANDROID
        _isAndroidBuild = true;
#else
        _isAndroidBuild = false;
#endif
    }

    private void SwitchInputMode(bool isAndroidBuild)
    {
        if (isAndroidBuild)
        {
            _androidControlButtons.SetActive(true);
            _playerController.enabled = false;
        }
        else
        {
            _androidControlButtons.SetActive(false);
            _playerController.enabled = true;
        }
    }

    private void SelectControlType()
    {
        CheckBuildType();
        SwitchInputMode(_isAndroidBuild);
        if (_isAndroidBuild)
        {
            Subscribe();
        }
    }

    private void Subscribe()
    {
        _escapeButton.onClick.AddListener(() => PlayLevel(0));
        _leftMoveButton.onClick.AddListener(OnLeftButtonClick);
        _rightMoveButton.onClick.AddListener(OnRightButtonClick);
        _jumpButton.onClick.AddListener(OnJumpButtonClick);
    }

    private void OnLeftButtonClick()
    {
        Debug.Log("left button clicked");
    }
    
    private void OnRightButtonClick()
    {
        Debug.Log("right button clicked");
    }
    
    private void OnJumpButtonClick()
    {
        Debug.Log("jump button clicked");
    }
    
}