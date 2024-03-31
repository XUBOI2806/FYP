using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isLaceKickingHash;
    int isSideKickingHash;

    // Init player input
    PlayerInput input;

    // variable to store player input
    Vector2 currentMovement;
    bool movementPressed;
    bool runPressed;
    bool sideKickPressed;
    bool laceKickPressed;

    // string to store button pressed

    // Awake is called when script is being loaded
    private void Awake()
    {
        input = new PlayerInput();

        input.CharacterControls.Move.performed += ctx => {
            onMovementInput(ctx);
        };

        input.CharacterControls.Move.canceled += ctx => {
            onMovementInput(ctx);
        };
        input.CharacterControls.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
        input.CharacterControls.Run.canceled += ctx => runPressed = ctx.ReadValueAsButton();


        input.CharacterControls.SideKick.performed += ctx =>
        {
            sideKickPressed = ctx.ReadValueAsButton();
        };

        input.CharacterControls.LaceKick.performed += ctx =>
        {
            laceKickPressed = ctx.ReadValueAsButton();
        };
    }

    void onMovementInput(InputAction.CallbackContext ctx)
    {
        currentMovement = ctx.ReadValue<Vector2>();
        movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
    }
    void Start()
    {
        // Get the animator component within the Unity Project
        animator = GetComponent<Animator>();
        // Converts string type to its own type
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isSideKickingHash = Animator.StringToHash("isSideKicking");
        isLaceKickingHash = Animator.StringToHash("isLaceKicking");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Side Kick Pressed?: " + sideKickPressed);
        handleRotation();
        handleMovement();
        handleShoot();
    }

    void handleShoot()
    {
        if(sideKickPressed)
        {
            animator.SetBool(isSideKickingHash, true);
        }
        if(!sideKickPressed)
        {
            animator.SetBool(isSideKickingHash, false);
        }
        if(laceKickPressed)
        {
            animator.SetBool(isLaceKickingHash, true);
        }
        if (!laceKickPressed)
        {
            animator.SetBool(isLaceKickingHash, false);
        }
    }
    void handleRotation()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);

        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    }
    void handleMovement()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        /*
        Debug.Log("Is running is " + isRunning);
        Debug.Log("Is walking is " + isWalking);
        Debug.Log("Movement pressed is " + movementPressed);
        Debug.Log("Running pressed is " + runPressed);
        */
        /*
        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
        
        if ((movementPressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        if ((!movementPressed || !runPressed) && isRunning) 
        {
            animator.SetBool(isRunningHash, false);
        }

        */

        if (movementPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (!movementPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (runPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        if (!runPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    private void OnEnable()
    {
        // enable character action map
        input.CharacterControls.Enable();

    }

    private void OnDisable()
    {
        // enable character action map
        input.CharacterControls.Disable();
    }
}
