using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private PlayerAttackEvent playerAttackEvent;

    private void Awake()
    {
        // Load components
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerAttackEvent = GetComponent<PlayerAttackEvent>();

    }

    private void OnEnable()
    {
        // Subscribe to idle event
        playerAttackEvent.OnPlayerAttack += playerAttackEvent_OnPlayerAttack;
    }

    private void OnDisable()
    {
        // Subscribe to idle event
        playerAttackEvent.OnPlayerAttack -= playerAttackEvent_OnPlayerAttack;
    }

    private void playerAttackEvent_OnPlayerAttack(PlayerAttackEvent playerAttackEvent, PlayerAttackArgs playerAttackArgs)
    {
        //MoveRigidBody();
    }

}
