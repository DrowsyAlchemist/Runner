using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _appearTime = 1;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _restartButton.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnPlayerDied()
    {
        Time.timeScale = 0;
        StartCoroutine(Appear());
    }

    private IEnumerator Appear()
    {
        while (_canvasGroup.alpha < 0.999f)
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, 1, Time.unscaledDeltaTime / _appearTime);
            yield return null;
        }
        _restartButton.gameObject.SetActive(true);
        _exitButton.gameObject.SetActive(true);
    }

    private void OnRestartButtonClick()
    {
        if (_player.IsAlive == false)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

    private void OnExitButtonClick()
    {
        if (_player.IsAlive == false)
            Application.Quit();
    }
}
