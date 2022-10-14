using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Background : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private RawImage _image;
    private Rect _rect;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        _rect = _image.uvRect;
    }

    private void Update()
    {
        float newX = _image.uvRect.x + _speed * Time.deltaTime;

        if (newX > 1)
            newX = 0;

        _image.uvRect = new Rect(newX, _rect.y, _rect.width, _rect.height);
    }
}
