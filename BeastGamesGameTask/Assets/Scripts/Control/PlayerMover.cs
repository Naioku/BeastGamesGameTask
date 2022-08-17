using System;
using UnityEngine;

namespace Control
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float speed = 12f;
        
        private CharacterController _controller;
        private float HorizontalInput => Input.GetAxis("Horizontal");
        private float VerticalInput => Input.GetAxis("Vertical");

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            ManageMovement();
        }

        private void ManageMovement()
        {
            Vector3 movement = transform.right * HorizontalInput + transform.forward * VerticalInput;
            _controller.Move(movement * speed * Time.deltaTime);
        }
    }
}
