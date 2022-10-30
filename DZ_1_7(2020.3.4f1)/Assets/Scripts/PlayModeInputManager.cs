using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayModeInputManager : BaseInputManager
{
    [SerializeField] private OldPlayerController _playerEditorController;
    [SerializeField] private PlayerAndroidController _playerAndroidController;
    [SerializeField] private Button _leftMoveButton;
    [SerializeField] private Button _rightMoveButton;
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _escapeButton;
    private bool _isAndroidBuild;
    private List<Button> _buttons;
    
    private void Start()
    {
        _buttons = new List<Button>();
        _buttons.Add(_leftMoveButton);
        _buttons.Add(_rightMoveButton);
        _buttons.Add(_jumpButton);
        _buttons.Add(_escapeButton);
       SelectControlType();
    }
    private void CheckBuildType()
    {
#if UNITY_ANDROID
        _isAndroidBuild = true;
#elif UNITY_STANDALONE || UNITY_EDITOR
        _isAndroidBuild = false;
#endif
    }

    private void SwitchInputMode(bool isAndroidBuild)
    {
        if (isAndroidBuild)
        {
            foreach (var button in _buttons)
            {
                button.gameObject.SetActive(true);
            }

            _playerAndroidController.enabled = true;
            _playerEditorController.enabled = false;
        }
        else
        {
            foreach (var button in _buttons)
            {
                button.gameObject.SetActive(false);
            }
            _playerEditorController.enabled = true;
            _playerAndroidController.enabled = false;
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