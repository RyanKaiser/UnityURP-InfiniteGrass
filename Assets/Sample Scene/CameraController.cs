using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _sensitivity = 2f;
    private float _yaw = 0f;
    private float _pitch = 0f;

    void Start()
    {
        if (_target == null)
            _target = GameObject.Find("Sphere").transform;
    }

    void LateUpdate()
    {
        _yaw += Input.GetAxis("Mouse X") * _sensitivity;
        _pitch -= Input.GetAxis("Mouse Y") * _sensitivity;
        _pitch = Mathf.Clamp(_pitch, -80f, 80f);

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        Vector3 offset = rotation * new Vector3(0, 0, -_distance);
        transform.position = _target.position + offset;
        transform.LookAt(_target.position); // 타겟을 바라봄
    }
}
