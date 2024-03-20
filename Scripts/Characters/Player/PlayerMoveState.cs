using System;
using Godot;

public partial class PlayerMoveState : PlayerState
{
  [Export(PropertyHint.Range, "0,20,0.1")] private float speed = 5;

    

    public override void _PhysicsProcess(double _delta)
    {
        if (characterNode.direction == Vector2.Zero) {
          characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
          return;
        }

        characterNode.Velocity = new(
          characterNode.direction.X,
          0,
          characterNode.direction.Y
        );
        
        characterNode.Velocity *= speed;
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    // public override void EnterState()
    // {
    //     base.EnterState();
    //     characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_WALK_SIDE);
    // }
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_WALK_SIDE);
    }
    
}