using GameAssets.Scripts.Controllers;
using GameAssets.Scripts.UI;
using UnityEngine;

namespace GameAssets.Scripts.Units.Heroes
{
    public class GameInputController : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private PopupInfoUI popupInfoUI;

        private const float C_infoPopupTime = 1f;
        private float holdTime;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.GetComponent<HeroObject>() != null)
                    {
                        hit.transform.gameObject.GetComponent<HeroObject>().Clicked();
                        playerController.LockOtherUnits();
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (!popupInfoUI.IsInfoActive)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.GetComponent<IInfoPopup>() != null)
                        {
                            holdTime += Time.deltaTime;
                            if (holdTime > C_infoPopupTime)
                            {
                                popupInfoUI.Initialize(hit.transform.gameObject.GetComponent<IInfoPopup>()
                                    .GetCharacterAttributes());
                                popupInfoUI.transform.position = hit.transform.position;
                                popupInfoUI.SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        holdTime = 0;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                holdTime = 0;
                if (popupInfoUI.IsInfoActive)
                    popupInfoUI.SetActive(false);
            }
        }
    }
}