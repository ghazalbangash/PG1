using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inputs
{
    // Start is called before the first frame update
    private static PlayerAction _actions;
    private static PlayerControler _owner;
    public static void BindNewPlayer(PlayerControler player){
        _owner = player;

    }
    public static void Init(PlayerControler player){
    _actions = new PlayerAction();
    BindNewPlayer(player);

    _actions.Player.Move.performed += ctx => _owner.Move(ctx.ReadValue<Vector2>());
    _actions.Player.Jump.performed += ctx => _owner.Jump();
    _actions.Player.shoot.performed += ctx => _owner.shoot();

    PlayMode();
    }

    public static void PlayMode(){
        _actions.Player.Enable();
    }
}
