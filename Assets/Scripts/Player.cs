using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public PlayerAIInteractions playerAiInteractions;
    public IMovementInput movementInput;
    public PlayerAnimations playerAnimations;
    public PlayerMovement playerMovement;
    public PlayerRenderer playerRenderer;
    public GameObject ui_window;

    public UiController uiController;

    private void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAiInteractions = GetComponent<PlayerAIInteractions>();
        movementInput = GetComponent<PlayerInput>();
        movementInput.OnInteractEvent += () => playerAiInteractions.Interact(playerRenderer.IsSpriteFlipped);
    }

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(movementInput.MovementInputVector);
        playerRenderer.RenderPlayer(movementInput.MovementInputVector);
        playerAnimations.SetupAnimations(movementInput.MovementInputVector);
        if (movementInput.MovementInputVector.magnitude > 0)
        {
            uiController.ToggleUI(false);
        }
    }


    public void ReceiveDamaged()
    {
        playerRenderer.FlashRed();
    }

}
