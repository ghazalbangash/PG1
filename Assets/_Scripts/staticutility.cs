using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticutility : MonoBehaviour
{
    // Start is called before the first frame update
     public static readonly int PlayerLayerID = 1 << LayerMask.NameToLayer("Player");
    public static readonly int EnemyLayerID = 1 << LayerMask.NameToLayer("enemy");
    public static readonly int GroundLayerID = 1 << LayerMask.NameToLayer("Ground");

    public static readonly int MoveLayers = PlayerLayerID | EnemyLayerID | GroundLayerID;



        
    //Animations
    public static readonly int XSpeedAnimID = Animator.StringToHash("xSpeed");
    public static readonly int ZSpeedAnimID = Animator.StringToHash("zSpeed");
    public static readonly int IdleAnimID = Animator.StringToHash("IdleState");
}