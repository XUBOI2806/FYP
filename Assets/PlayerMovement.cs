using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    // store the right foot for kicking actions
    public GameObject RightFoot;

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

    // string to store restart button pressed
    bool restartPressed;

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

        input.CharacterControls.Restart.performed += ctx =>
        {
            restartPressed = ctx.ReadValueAsButton();
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

        // ad hoc fix to prevent player from sinking
        /*
        Vector3 currentPosition = transform.position;
        currentPosition.y = 0;
        transform.position = currentPosition;
        */

        // call handlers for all inputs
        handleRotation();
        handleMovement();
        handleShoot();
        handleRestart();
    }

    void handleRestart()
    {
        if (restartPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void handleShoot()
    {
        if(sideKickPressed)
        {
            Debug.Log("Side Kick Pressed");
            RightFoot.GetComponent<KickBall>().enableSideKicking();
            animator.SetBool(isSideKickingHash, true);
        }
        if(!sideKickPressed)
        {
            RightFoot.GetComponent<KickBall>().disableSideKicking();
            animator.SetBool(isSideKickingHash, false);
        }
        if(laceKickPressed)
        {
            Debug.Log("Lace Kick Pressed");
            RightFoot.GetComponent<KickBall>().enableLaceKicking();
            animator.SetBool(isLaceKickingHash, true);
        }
        if (!laceKickPressed)
        {
            RightFoot.GetComponent<KickBall>().disableLaceKicking();
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
