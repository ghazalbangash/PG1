using UnityEngine;

public static class Inputs
{

    private static PlayerAction _actions;
    private static PlayerControler _owner;

    //Allows to not rebind all the functions, just the player.
    //Given the context we're doing this. this function is actually bad, but sometimes it's useful.
    public static void BindNewPlayer(PlayerControler player)
    {
        _owner = player;
    }


    public static void Init(PlayerControler player)
    {
        _actions = new PlayerAction();

        //Unnecessary, but neater.
        BindNewPlayer(player);
        
        // BIND ACTIONS   
        //_actions.Player.Look.performed += ctx => _owner.SetLook(ctx.ReadValue<Vector2>());
        _actions.Player.Move.performed += ctx => _owner.Move(ctx.ReadValue<Vector2>());
        _actions.Player.Jump.performed += ctx => _owner.Jump();
       // _actions.Player.Shoot.performed += ctx => _owner.TryShoot();
        
            
        // ENABLE DEFAULT ACTION MAPS    
            
        //Permanent actions are useful for reading information that should always exist. 
        //This can be handy for if you want to track the mouse position at all times.
        //_actions.Permanent.Enable();
            
        //Set to playmode by default
        PlayMode();
    }

    // public static void UIMode()
    // {
    //     _actions.Player.Disable();
    //     _actions.UI.Enable();
    // }

    public static void PlayMode()
    {
        _actions.Player.Enable();
        //_actions.UI.Disable();
    }

}
