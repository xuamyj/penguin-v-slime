using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera mainCamera;

    // private GameUIController gameUIController; // before static

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // gameUIController = GameObject.FindWithTag("GameController").GetComponent<GameUIController>(); // before static
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
            GameUIController.instance.EditNumLives(-1);

            if (GameUIController.instance.IsGameOver())
            {
                // gameUIController.ShowGameOverScreen(); // before static
                GameUIController.instance.ShowGameOverScreen();
            }
        }
    }
}
