using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerGroundState
{
    public IdleState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
}
