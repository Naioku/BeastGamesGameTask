using UnityEngine;

namespace Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject hitEffect;
        [SerializeField] private float maxLifeTime = 10f;

        private Rigidbody _rigidbody;
        private Vector3 _destinationVector;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _rigidbody.velocity = _destinationVector * speed;
        }

        public void SetProjectileDirection(Vector3 destinationPoint, Vector3 firePoint)
        {
            transform.LookAt(destinationPoint);
            _destinationVector = (destinationPoint - firePoint).normalized;
            
            Destroy(gameObject, maxLifeTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (hitEffect != null)
            {
                Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
