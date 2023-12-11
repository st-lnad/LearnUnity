using UnityEngine;

public class Anim2 : MonoBehaviour
{
    [SerializeField, Min(0.001f), Tooltip("Speed in grad/s")] private float _speed;
    private Vector3 _axis = new Vector3(0, 1, 0);

    private void Update()
    {
        transform.RotateAround(transform.position, _axis, _speed * Time.deltaTime);
    }
}
