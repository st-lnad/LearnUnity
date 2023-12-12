using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _cooldown;
    public Transform Target;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }
    private IEnumerator _shootingWorker()
    {
        bool isWork = enabled;
        var delay = new WaitForSeconds(_cooldown);
        while (isWork)
        {
            Vector3 _direction = (Target.position - transform.position).normalized;
            Rigidbody NewBullet = Instantiate(_bulletPrefab, transform.position + _direction, Quaternion.identity);

            NewBullet.transform.up = _direction;
            NewBullet.velocity = _direction * _bulletSpeed;

            yield return delay;
        }
    }
}