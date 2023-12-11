using UnityEngine;

public class Anim3 : MonoBehaviour
{
    [SerializeField, Min(0.001f)] private float _maxScale;
    [SerializeField, Min(0.001f), Tooltip("Speed in unit/s")] private float _speed;
    private int _animationDirection;
    private Vector3 _startScale;
    private float[] _scaleBorders;

    private void Awake()
    {
        _startScale = transform.localScale;
        _animationDirection = (_maxScale >= 1f) ? 1 : -1;
        _scaleBorders = new float[2] { Mathf.Min(_startScale.x, _maxScale), Mathf.Max(_startScale.x, _maxScale), };
    }

    private void OnValidate()
    {
        _scaleBorders = new float[2] {Mathf.Min(_startScale.x, _maxScale), Mathf.Max(_startScale.x, _maxScale), };
    }

    private void Update()
    {
        float multiplier;
        float nextState = transform.localScale.x + _speed * Time.deltaTime * _animationDirection;
        if (_scaleBorders[0] < nextState && nextState < _scaleBorders[1])
        {
            multiplier = nextState / transform.localScale.x;
        }   
        else
        {
            _animationDirection *= -1;
            if (_scaleBorders[0] >= nextState)
                multiplier = _scaleBorders[0] / transform.localScale.x;
            else
                multiplier = _scaleBorders[1] / transform.localScale.x;
        }
        transform.localScale = transform.localScale * multiplier;
    }
}
