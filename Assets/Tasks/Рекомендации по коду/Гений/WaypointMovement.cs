using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointRoot;
    [SerializeField] private GameObject _waypoint;

    private Transform[] _waypoints;
    private int _currentWaypointIndex;
    private Vector3 _currentWaypointPosition;

    private void Start()
    { 
        _waypoints = new Transform[_waypointRoot.childCount];

        for (int i = 0; i < _waypointRoot.childCount; i++)
            _waypoints[i] = _waypointRoot.GetChild(i);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypointPosition, _speed * Time.deltaTime);

        if (transform.position == _currentWaypointPosition) 
            GetNextWaypoint();
    }

    private void GetNextWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _waypoints.Length)
            _currentWaypointIndex = 0;

        _currentWaypointPosition = _waypoints[_currentWaypointIndex].transform.position;
        transform.forward = _currentWaypointPosition - transform.position;
    }
}
