using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneButtons : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Camera.main.ScreenToWorldPoint(touch.position).x > 0)
            {
                PlayerController.Instance.MoveRight();
            }
            else
            {
                PlayerController.Instance.MoveLeft();
            }

        }
    }
}