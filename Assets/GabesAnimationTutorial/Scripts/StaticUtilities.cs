using UnityEngine;

public static class StaticUtilities
{
    //Layers
    public static readonly int PlayerLayerID = 1 << LayerMask.NameToLayer("Player");
    public static readonly int EnemyLayerID = 1 << LayerMask.NameToLayer("Enemy");
    public static readonly int GroundLayerID = 1 << LayerMask.NameToLayer("Ground");

    public static readonly int MoveLayers = PlayerLayerID | EnemyLayerID | GroundLayerID;
    public static readonly int AttackLayers =  EnemyLayerID | GroundLayerID;
    
    //Animations
    public static readonly int XSpeedAnimID = Animator.StringToHash("xSpeed");
    public static readonly int ZSpeedAnimID = Animator.StringToHash("zSpeed");
    public static readonly int IdleAnimID = Animator.StringToHash("IdleState");
    public static readonly int AttackAnimID = Animator.StringToHash("Attack");
    public static readonly int TurnAnimID = Animator.StringToHash("Turn");
    public static readonly int IsTurningAnimID = Animator.StringToHash("isTurning");

}
