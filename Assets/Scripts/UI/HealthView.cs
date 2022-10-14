using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _layout;
    [SerializeField] private Image _template;
    [SerializeField] private float _fillTime = 1;

    private Queue<Image> _queue = new Queue<Image>();

    private void Start()
    {
        for (int i = 0; i < _player.Health; i++)
        {
            Image healthImage = Instantiate(_template, _layout);
            _queue.Enqueue(healthImage);
            StartCoroutine(FillImage(healthImage));
        }
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        int imageAmount = _queue.Count;
        health = Mathf.Clamp(health, 0, _player.MaxHealth);

        if (health > imageAmount)
        {
            for (int i = 0; i < health - imageAmount; i++)
            {
                Image newImage = Instantiate(_template, _layout);
                _queue.Enqueue(newImage);
                Image image = _queue.Peek();
                StartCoroutine(FillImage(image));
            }
        }
        else
        {
            for (int i = 0; i < imageAmount - health; i++)
            {
                Image image = _queue.Dequeue();
                image.gameObject.SetActive(false);
            }
        }

    }

    private IEnumerator FillImage(Image image)
    {
        image.fillAmount = 0;

        while (image.fillAmount < 1)
        {
            image.fillAmount = Mathf.MoveTowards(image.fillAmount, 1, Time.deltaTime / _fillTime);
            yield return null;
        }
    }

    private void OnValidate()
    {
        _template.type = Image.Type.Filled;
        _template.fillMethod = Image.FillMethod.Radial360;
        _template.fillAmount = 1;
    }
}
