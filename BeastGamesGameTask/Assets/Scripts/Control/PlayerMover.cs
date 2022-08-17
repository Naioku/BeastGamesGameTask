using UnityEngine;

namespace Control
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float speed = 12f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float gravity = -150f;
        [SerializeField] private float jumpHeight = 3f;
        
        private CharacterController _controller;
        private Vector3 _velocity;
        private float HorizontalInput => Input.GetAxis("Horizontal");
        private float VerticalInput => Input.GetAxis("Vertical");
        private bool IsGrounded => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            ManageMovement();
            ManagePhysics();
            ManageJump();
            
            ApplyVelocity();
        }

        private void ManageMovement()
        {
            Vector3 movement = transform.right * HorizontalInput + transform.forward * VerticalInput;
            _controller.Move(movement * speed * Time.deltaTime);
        }

        private void ManagePhysics()
        {
            if (IsGrounded && _velocity.y < 0f)
            {
                _velocity.y = -0.5f;
            }

            _velocity.y += 0.5f * gravity * Time.deltaTime;

        }

        private void ManageJump()
        {
            if (Input.GetButtonDown("Jump") && IsGrounded)
            {
                _velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        private void ApplyVelocity()
        {
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}
