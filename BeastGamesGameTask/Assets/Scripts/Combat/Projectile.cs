using Core;
using UnityEngine;

namespace Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject hitEffect;
        [SerializeField] private float maxLifeTime = 10f;
        [SerializeField] private float damage;
        [SerializeField] private CombatMaterial combatMaterial;

        private Rigidbody _rigidbody;
        private Vector3 _destinationVector;

        public float Damage => damage;
        public CombatMaterial CombatMaterial => combatMaterial;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _rigidbody.velocity = _destinationVector * speed;
        }

        public void PrepareProjectile(Vector3 destinationPoint, Vector3 firePoint, float damage)
        {
            SetProjectileDirection(destinationPoint, firePoint);
            SetDamage(damage);
            
            Destroy(gameObject, maxLifeTime);
        }

        private void SetProjectileDirection(Vector3 destinationPoint, Vector3 firePoint)
        {
            transform.LookAt(destinationPoint);
            _destinationVector = (destinationPoint - firePoint).normalized;
            
            Destroy(gameObject, maxLifeTime);
        }

        private void SetDamage(float damage) =>this.damage += damage;

        private void OnTriggerEnter(Collider other)
        {
            if (hitEffect != null)
            {
                Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            }

            var combatTarget = other.GetComponent<CombatTarget>();
            if (combatTarget != null && combatTarget.CombatMaterial == combatMaterial)
            {
                combatTarget.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
