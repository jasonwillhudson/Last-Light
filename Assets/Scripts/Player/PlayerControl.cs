using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]

public class PlayerControl : MonoBehaviour
{
    #region Tooltip

    [Tooltip("MovementDetailsSO scriptable object containing movement details such as speed")]

    #endregion Tooltip

    [SerializeField] private MovementDetailsSO movementDetails;

    [SerializeField] private Transform weaponShootPosition;
    private Player player;
    private float moveSpeed;
    private float attackTimer = 0f;


    private bool isPlayerMovementDisabled = false;
    private bool isRotaionDisabled = false;

  

    [HideInInspector] public bool isPlayerRolling = false;

    private void Awake()
    {
        // Load components
        player = GetComponent<Player>();

        moveSpeed = movementDetails.GetMoveSpeed();
    }

    private void Start()
    {

        // Set player animation speed
        SetPlayerAnimationSpeed();

    }


    public bool getAttackStatus(){
        return isRotaionDisabled; // true if it is attacking
}


    /// <summary>
    /// Set player animator speed to match movement speed
    /// </summary>
    private void SetPlayerAnimationSpeed()
    {
        // Set animator speed to match movement speed
        player.animator.speed = moveSpeed / Settings.baseSpeedForPlayerAnimations;
    }

    private void Update()
    {


        // if player movement disabled then return
        if (isPlayerMovementDisabled)
            return;

        // Process the player movement input
        MovementInput();

        //player attack input
        PlayerAttackInput();
        Debug.Log("isRotation DIsabled?" + isRotaionDisabled);
        //if weapon rotation is disabled then return
        if (isRotaionDisabled) return;
        WeaponInput();


    }

    //player attack input
    private void PlayerAttackInput()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            isRotaionDisabled = true; //weapon not allow to rotate with mouse when attacking
             
        }
        else
        {
            isRotaionDisabled = false;
            player.playerAttackEvent.CallPlayerAttackEvent("attack_1", false);//call the attack event

            if (Input.GetMouseButtonDown(0))
            {
                player.playerAttackEvent.CallPlayerAttackEvent("attack_1", true);//call the attack event
                Debug.Log("Attack");
                attackTimer = 0.5f;
            }
        }
        
    }

    /// Player movement input

    private void MovementInput()
    {
        // Get movement input
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");


        // Create a direction vector based on the input
        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);

        // Adjust distance for diagonal movement (pythagoras approximation)
        if (horizontalMovement != 0f && verticalMovement != 0f)
        {
            direction *= 0.7f;
        }

        // If there is movement either move or roll
        if (direction != Vector2.zero)
        {
                // trigger movement event
                player.movementByVelocityEvent.CallMovementByVelocityEvent(direction, moveSpeed);
        }
        // else trigger idle event
        else
        {
            player.idleEvent.CallIdleEvent();
        }
    }

   private void WeaponInput()
    {
        Vector3 weaponDirection;
        float weaponAngleDegrees, playerAngleDegrees;
        AimDirection playerAimDirection;

        AimWeaponInput(out weaponDirection, out weaponAngleDegrees, out playerAngleDegrees, out playerAimDirection);
    }

    private void AimWeaponInput(out Vector3 weaponDirection, out float weaponAngleDegrees, out float playerAngleDegrees, out AimDirection playerAimDirection)
    { 
        // Get mouse world position
        Vector3 mouseWorldPosition = HelperUtilities.GetMouseWorldPosition();

        // Calculate direction vector of mouse cursor from weapon shoot position
       weaponDirection = (mouseWorldPosition - weaponShootPosition.position);

        // Calculate direction vector of mouse cursor from player transform position
        Vector3 playerDirection = (mouseWorldPosition - transform.position);

        // Get weapon to cursor angle
        weaponAngleDegrees = HelperUtilities.GetAngleFromVector(weaponDirection);

        // Get player to cursor angle
        playerAngleDegrees = HelperUtilities.GetAngleFromVector(playerDirection);

        // Set player aim direction
        playerAimDirection = HelperUtilities.GetAimDirection(playerAngleDegrees);

        // Trigger weapon aim event
        player.aimWeaponEvent.CallAimWeaponEvent(playerAimDirection, playerAngleDegrees, weaponAngleDegrees, weaponDirection);
    }




    /// <summary>
    /// Enable the player movement
    /// </summary>
    public void EnablePlayer()
    {
        isPlayerMovementDisabled = false;
    }

    /// <summary>
    /// Disable the player movement
    /// </summary>
    public void DisablePlayer()
    {
        isPlayerMovementDisabled = true;
        player.idleEvent.CallIdleEvent();
    }

    /// <summary>
    /// Set the current weapon to be first in the player weapon list
    /// </summary>



    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(movementDetails), movementDetails);
    }


}