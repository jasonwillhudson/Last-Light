using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerAttackEvent : MonoBehaviour
{
    public event Action<PlayerAttackEvent, PlayerAttackArgs> OnPlayerAttack;

    public void CallPlayerAttackEvent(string skilltype, bool isAttacking)
    {
        OnPlayerAttack?.Invoke(this, new PlayerAttackArgs() { skilltype = skilltype, isAttacking = isAttacking });
    }


}

public class PlayerAttackArgs : EventArgs
{
    public string skilltype;
    public bool isAttacking;
}

