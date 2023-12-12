using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float _xMaxScale;
    [SerializeField, Tooltip("Speed in unit/s")] private float _speed;
    private int _animationDirection;
    private float _xStartScale;
    private float[] _scaleBorders;

    private void Awake()
    {
        _xStartScale = transform.localScale.x;
        _animationDirection = (_xMaxScale >= _xStartScale) ? 1 : -1;
        _scaleBorders = new float[2] { Mathf.Min(_xStartScale, _xMaxScale), Mathf.Max(_xStartScale, _xMaxScale), };
    }

    private void OnValidate()
    {
        _scaleBorders = new float[2] {Mathf.Min(_xStartScale, _xMaxScale), Mathf.Max(_xStartScale, _xMaxScale), };
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
