using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxVolume = 1f;
    private AudioSource _audioSource;
    private float _volume = 0f;
    private float _targetVolume = 0f;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetVolume = _maxVolume;
        if (_volume == 0f)
            _audioSource.Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetVolume = 0f;
    }
    private void Update()
    {
        _volume = Mathf.MoveTowards(_volume, _targetVolume, _speed * Time.deltaTime);
        if (_volume == 0f)
            _audioSource.Stop();
        _audioSource.volume = _volume;
    }
}
