using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(ShowHideCanvas))]
    public class HelpInfo : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetButton("Help"))
            {
                ShowCanvas();
            }
            else
            {
                HideCanvas();
            }
        }

        private void HideCanvas()
        {
            GetComponent<ShowHideCanvas>().HideCanvas();
        }
        
        private void ShowCanvas()
        {
            GetComponent<ShowHideCanvas>().ShowCanvas();
        }
    }
}
