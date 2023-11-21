using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class Inputs
{
    // Start is called before the first frame update
    private static PlayerAction _actions;
    private static PlayerControler _owner;

    public static void BindNewPlayer(PlayerControler player){
        _owner = player;

    }




    
    private static Camera _camera;

    private static float _cameraLerpPercent = 0.5f;
    private static readonly Vector3 CamPointA = new (0,20,-15);
    private static readonly Vector3 CamPointB = new (0,2,-2);

    public static void SetCommander(PlayerControler newTarget)
    {
        _owner = newTarget;
        if(_camera) _camera.transform.SetParent(_owner.transform, true);
    }

    public static void SetControlledCamera(Camera newCam)
    {
        _camera = newCam;
        _camera.transform.SetParent(_owner.transform, true);
        //HandleCameraLerp(0);
    }
    public static void Init(PlayerControler player,Camera cam = null){


    SetCommander(player);
    SetControlledCamera(cam?cam:Camera.main);
    _actions = new PlayerAction();
    BindNewPlayer(player);

    _actions.Player.Move.performed += ctx => _owner.Move(ctx.ReadValue<Vector2>());
    _actions.Player.Jump.performed += ctx => _owner.Jump();
    _actions.Player.MovingTo.performed += ctx => _owner.MoveTo(CamToWorldRay());
    //_actions.Player.shoot.performed += ctx => _owner.shoot();

    PlayMode();
    }

    // public static void InitEnemy(EnemyControler enemy,Camera cam = null){
    // _actions = new PlayerAction();
    // BindEnemy(enemy);
    // SetCommander(enemy);
    // SetControlledCamera(cam?cam:Camera.main);

    // Debug.Log("Enemy here ");

    // _actions.Enemy.MoveTo.performed += ctx => _enemy.MoveTo(CamToWorldRay());


    // PlayMode();
    // }

    public static void PlayMode(){
        _actions.Player.Enable();
    }


    private static Ray CamToWorldRay()
    {
        return _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
    }
}
