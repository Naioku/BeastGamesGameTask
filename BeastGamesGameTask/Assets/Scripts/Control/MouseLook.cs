using UnityEngine;

namespace Control
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private Transform playerBody;
        
        private float _xRotation;

        private float MouseXInput => Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        private float MouseYInput => Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            ManageCameraHorizontalRotation();
            ManageCameraVerticalRotation();
        }

        private void ManageCameraHorizontalRotation()
        {
            playerBody.Rotate(Vector3.up * MouseXInput);
        }

        private void ManageCameraVerticalRotation()
        {
            _xRotation -= MouseYInput;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }
    }
}
