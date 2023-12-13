using System.Collections;
using UnityEngine;

public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _cooldown;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private IEnumerator _shootingWorker()
    {
        bool isWork = enabled;
        var delay = new WaitForSeconds(_cooldown);
        while (isWork)
        {
            Vector3 _direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_bulletPrefab, transform.position + _direction, Quaternion.identity);

            newBullet.transform.up = _direction;
            newBullet.velocity = _direction * _bulletSpeed;

            yield return delay;
        }
    }
}