using UnityEngine;

public class ForwardAnimation : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
    }
}
