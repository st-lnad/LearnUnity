using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform WaypointRoot;
    private Transform[] _waypoints;
    private int _currentWaypointIndex;
    private void Start()
    { 
        _waypoints = new Transform[WaypointRoot.childCount];

        for (int i = 0; i < WaypointRoot.childCount; i++)
            _waypoints[i] = WaypointRoot.GetChild(i).transform;
    }
    private void Update()
    {
        var _pointByNumberInArray = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position) GetNextWaypoint();
    }
    private Vector3 GetNextWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _waypoints.Length)
            _currentWaypointIndex = 0;

        var currentWaypointPosition = _waypoints[_currentWaypointIndex].transform.position;
        transform.forward = currentWaypointPosition - transform.position;
        return currentWaypointPosition;
    }
}
