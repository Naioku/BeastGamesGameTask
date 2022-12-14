using UI;
using UnityEngine;
using UnityEngine.Pool;

namespace Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private Transform firePointTransform;
        [SerializeField] private Camera fpCamera;
        [SerializeField] private float range = 100f;
        [SerializeField] private float timeBetweenShots;
        [SerializeField] private float damage = 5f;
        
        [Tooltip("Where projectiles have to be stored in the Hierarchy?")]
        [SerializeField] private Transform projectilesParentInHierarchy;
        
        private CombatTargetInfo _combatTargetInfo;
        private WeaponInfo _weaponInfo;
        private Vector3 _destinationPoint;
        private float _timeSinceLastShot = Mathf.Infinity;
        private IObjectPool<Projectile> _projectilePool;

        private void Start()
        {
            _combatTargetInfo = FindObjectOfType<CombatTargetInfo>();
            _weaponInfo = FindObjectOfType<WeaponInfo>();
            _projectilePool = new ObjectPool<Projectile>(
                CreateProjectile,
                OnGet,
                OnRelease,
                OnDestroyProjectile);
        }

        private void Update()
        {
            Aim();
            ManageShooting();
            UpdateTimer();
            UpdateWeaponInfo();
        }
        
        private Projectile CreateProjectile()
        {
            Projectile projectileInstance = Instantiate(
                projectile, 
                firePointTransform.position,
                transform.rotation,
                projectilesParentInHierarchy != null? projectilesParentInHierarchy : null);
            
            projectileInstance.SetPool(_projectilePool);
            return projectileInstance;
        }

        private void OnGet(Projectile obj)
        {
            obj.gameObject.SetActive(true);
            obj.transform.position = firePointTransform.position;
            
            obj.PrepareProjectile(
                _destinationPoint,
                firePointTransform.position,
                damage);
        }

        private void OnRelease(Projectile obj)
        {
            if (!obj.enabled) return;
            
            obj.gameObject.SetActive(false);
        }

        private void OnDestroyProjectile(Projectile obj)
        {
            Destroy(obj.gameObject);
        }

        private void UpdateWeaponInfo()
        {
            float damageSum = damage + projectile.Damage;
            _weaponInfo.UploadInfo(damageSum, projectile.CombatMaterial);
        }

        private void Aim()
        {
            Ray ray = GetRay();
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _destinationPoint = hit.point;
                ManageShowingTargetInfo(hit);
            }
            else
            {
                _destinationPoint = ray.GetPoint(range);
            }
        }

        private void ManageShowingTargetInfo(RaycastHit hit)
        {
            var combatTarget = hit.transform.GetComponent<CombatTarget>();
            if (combatTarget != null)
            {
                _combatTargetInfo.UploadInfo(
                    combatTarget.Health,
                    combatTarget.MaxHealth,
                    combatTarget.CombatMaterial);
                
                _combatTargetInfo.ShowCanvas();
            }
            else
            {
                _combatTargetInfo.HideCanvas();
            }
        }

        private void ManageShooting()
        {
            if (Input.GetButton("Fire1") && _timeSinceLastShot >= timeBetweenShots)
            {
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
            _projectilePool.Get();
        }

        private void UpdateTimer()
        {
            _timeSinceLastShot += Time.deltaTime;
        }
    }
}
