using UnityEngine;

namespace Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private Transform firePointTransform;
        [SerializeField] private Camera fpCamera;
        [SerializeField] private float range = 100f;
        [SerializeField] private float timeBetweenShots;

        private Vector3 _destinationPoint;
        private float _timeSinceLastShot = Mathf.Infinity;

        void Update()
        {
            ManageShooting();
            UpdateTimer();
        }

        private void ManageShooting()
        {
            if (Input.GetButton("Fire1") && _timeSinceLastShot >= timeBetweenShots)
            {
                Ray ray = GetRay();
                RaycastHit hit;

                _destinationPoint = Physics.Raycast(ray, out hit) ? hit.point : ray.GetPoint(range);

                LunchProjectile();
                _timeSinceLastShot = 0f;
            }
        }

        private Ray GetRay()
        {
            return fpCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        }

        private void LunchProjectile()
        {
            Projectile projectileInstance = Instantiate(
                projectile, 
                firePointTransform.position,
                transform.rotation);
            
            projectileInstance.SetProjectileDirection(_destinationPoint, firePointTransform.position);
        }

        private void UpdateTimer()
        {
            _timeSinceLastShot += Time.deltaTime;
        }
    }
}
