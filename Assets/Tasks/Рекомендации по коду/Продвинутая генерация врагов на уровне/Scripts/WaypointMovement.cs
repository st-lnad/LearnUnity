using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypointIndex = 0;
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;
    private float _elapsedTime;
    private float _expectedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        transform.position = Vector3.Lerp(_previousPosition, _currentPosition, _elapsedTime / _expectedTime);
        if (_elapsedTime >= _expectedTime)
            ComputeWayToNextPoint();
    }

    private void Awake()
    {
        ComputeWayToNextPoint();
    }

    private void ComputeWayToNextPoint()
    {
        _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Count;
        _currentPosition = _waypoints[_currentWaypointIndex].position;
        if (_currentWaypointIndex == 0)
            _previousPosition = _waypoints[^1].position;
        else
            _previousPosition = _waypoints[_currentWaypointIndex-1].position;

        _expectedTime = (_currentPosition - _previousPosition).magnitude / _speed;
        _elapsedTime = 0f;
    }
}
