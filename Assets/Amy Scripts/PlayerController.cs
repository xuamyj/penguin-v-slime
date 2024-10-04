using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera mainCamera;

    // DEBUG TODO
    private GameUIController gameUIController;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // DEBUG TODO
        gameUIController = GameObject.FindWithTag("GameController").GetComponent<GameUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the same z-position as the player

        transform.position = mousePosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // DEBUG TODO
            gameUIController.ShowGameOverScreen();
        }
    }
}
