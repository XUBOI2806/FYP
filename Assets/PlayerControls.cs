using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that defines actions other than movements, such as resetting the game, changing target locations and distance to kick
public class PlayerControls : MonoBehaviour
{
    // Open the player input class
    PlayerInput input;

    // Booleans for storing inputs
    private bool randomisePressed;


    // public GameObject to store target controllers
    public GameObject goal;

    // Awake called before the first frame
    private void Awake()
    {
        input = new PlayerInput();

        input.CharacterControls.RandomiseTarget.performed += ctx =>
        {
            randomisePressed = ctx.ReadValueAsButton();
            Debug.Log("T pressed");
        };


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleRandomise();
    }


    // Function to randomise the target locations
    void handleRandomise()
    {
        // Do the ranodmising here
        
        if (randomisePressed)
        {
            goal.GetComponent<TargetController>().randomiseTargets();
        }
    }
}
