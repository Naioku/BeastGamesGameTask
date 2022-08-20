using UnityEngine;

namespace Mechanisms
{
    public class HiddenDoorController : MonoBehaviour
    {
        [SerializeField] private GameObject hiddenDoor;
        
        private Animator _animator;
        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");

        private void Awake()
        {
            _animator = hiddenDoor.GetComponent<Animator>();
        }

        public void OpenTheDoor() => _animator.SetTrigger(Open);
        public void CloseTheDoor() => _animator.SetTrigger(Close);
    }
}
