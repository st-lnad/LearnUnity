using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        Vector3 offset = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(offset.normalized * _speed * Time.deltaTime);
    }
}
