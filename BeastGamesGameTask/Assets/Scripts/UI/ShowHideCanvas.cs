using UnityEngine;

namespace UI
{
    public class ShowHideCanvas : MonoBehaviour
    {
        [Tooltip("Default visibility level of the canvas. Opposite of the opacity.")] 
        [SerializeField] [Range(0f, 1f)] private float alpha = 0.8f;

        private CanvasGroup _canvasGroup;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            HideCanvas();
        }

        public void HideCanvas()
        {
            _canvasGroup.alpha = 0f;
        }

        public void ShowCanvas()
        {
            _canvasGroup.alpha = alpha;
        }
    }
}
