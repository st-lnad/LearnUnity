using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    [SerializeField, Tooltip("Speed in grad/s")] private float _speed;
    private Vector3 _yAxis = new Vector3(0, 1, 0);

    private void Update()
    {
        transform.RotateAround(transform.position, _yAxis, _speed * Time.deltaTime);
    }
}
