using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingCircleController : MonoBehaviour
{
    /* ---- Mouse click hold letgo ----*/
    public float hittingToPlanningRatio;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the same z-position as the player

        transform.position = mousePosition;
    }
}
