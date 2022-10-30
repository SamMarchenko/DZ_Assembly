using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] _blocks;
    [SerializeField] private int _health = 3;
    [SerializeField] private Text _progressText;
    [SerializeField] private Text _healthText;
    [SerializeField] private float _levelTimer = 100;
    [SerializeField] private Text _timerText;
    private int _progress = 0;
    private int _currentIndex = 0;
    private float _lastZ = 90f;
    private float _stepZ = 10f;


    private void Update()
    {
        UpdateTimer();
        _timerText.text = $"Timer: {(int) _levelTimer}";
        if (_player.position.y <= -1f)
        {
            _health = 0;
            SetDamage(1);
        }

        if (_levelTimer <= 0)
        {
            GameOver();
        }
    }

    public void UpdateLevel()
    {
        _progress++;
        _progressText.text = $"Progress: {_progress}";

        _lastZ += _stepZ;
        var position = _blocks[_currentIndex].position;
        position.z = _lastZ;
        _blocks[_currentIndex].position = position;
        _currentIndex++;
        if (_currentIndex >= _blocks.Length)
        {
            _currentIndex = 0;
        }
    }

    public void SetDamage(int damage)
    {
        _health -= damage;
        _healthText.text = $"Health: {_health}";
        Debug.Log($"--- Player current health: {_health} ---");
        if (_health <= 0)
        {
            GameOver();
        }
    }

    private void UpdateTimer()
    {
        _levelTimer -= Time.deltaTime;
    }

    
    private void GameOver()
    {
        if (_health <= 0)
        {
            _health = 0;
            Debug.Log($"--- Player DIED ---");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#elif UNITY_ANDROID
            SceneManager.LoadScene(0);
#endif
        }

        if (_levelTimer > 0) return;

        Debug.Log($"--- Time is OVER ---");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPaused = true;
#elif UNITY_ANDROID
           SceneManager.LoadScene(0);
#endif
    }
}