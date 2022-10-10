using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputController : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<HeroObject>() != null)
                {
                    hit.transform.gameObject.GetComponent<HeroObject>().Clicked();
                }
            }   
        }
    }
}
