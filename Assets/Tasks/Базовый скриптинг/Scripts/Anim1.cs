using log4net.DateFormatter;
using UnityEngine;

public class Anim1 : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField, Min(0.001f)] private float _period;
    private float _t;
    private Vector3 _startPoint;
    private float _halfPeriod;

    private void Awake()
    {
        _t = 0f;
        _startPoint = transform.position;
        _halfPeriod = _period / 2f;
    }
    private void OnValidate()
    {
        _halfPeriod = _period / 2f;
    }

    private void Update()
    {
        _t += Time.deltaTime;
        if ( _t > _halfPeriod)  
            _t -= _halfPeriod * 2f;
        transform.position = Vector3.Lerp(
            _startPoint,
            _startPoint + transform.forward * _distance,
            Mathf.Abs(_t) / _halfPeriod
            );
    }
}
