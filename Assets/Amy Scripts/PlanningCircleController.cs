using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlanningCircleController : MonoBehaviour
{
    /* ---- Mouse click hold letgo ----*/
    public float XToYRatio;
    public float growSpeed;
    float scaleX;
    float scaleY;
    public InputAction MouseLeftButtonAction;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 5;

        mainCamera = Camera.main;

        /* ---- Mouse click hold letgo ----*/
        MouseLeftButtonAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the same z-position as the player

        transform.position = mousePosition;

        // UnityEngine.Debug.Log("IsPressed(): " + MouseLeftButtonAction.IsPressed());
        // UnityEngine.Debug.Log("WasPressedThisFrame(): " + MouseLeftButtonAction.WasPressedThisFrame());
        // UnityEngine.Debug.Log("WasPerformedThisFrame(): " + MouseLeftButtonAction.WasPerformedThisFrame());
        // UnityEngine.Debug.Log("WasReleasedThisFrame(): " + MouseLeftButtonAction.WasReleasedThisFrame() + "\n");

        /* ---- Mouse click hold letgo ----*/
        if (MouseLeftButtonAction.WasPressedThisFrame()) // mouseClick
        {
            scaleY = 0.1f;
            scaleX = XToYRatio * 0.1f;
        }
        else if (MouseLeftButtonAction.WasReleasedThisFrame()) // mouseRelease
        {
            scaleY = 0.0f;
            scaleX = 0.0f;
        }
        else if (MouseLeftButtonAction.IsPressed()) // mouseHold
        {
            scaleY = scaleY + growSpeed * Time.deltaTime;
            scaleX = XToYRatio * scaleY;
        }
        transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
    }

    // FixedUpdate() is only for Rigidbodys
}
