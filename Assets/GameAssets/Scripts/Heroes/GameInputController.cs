using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private PlayerController playerController;

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
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<IInfoPopup>() != null)
                {
                    holdTime += Time.deltaTime;
                    hit.transform.gameObject.GetComponent<IInfoPopup>().Focused();
                }
            }
            else
            {
                holdTime = 0;
            }
        }
        else
        {
            holdTime = 0;
        }
    }
}