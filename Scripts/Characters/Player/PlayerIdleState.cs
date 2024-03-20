using Godot;

public partial class PlayerIdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction != Vector2.Zero) {
          characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
        }
    }
    // public override void EnterState()
    // {
    //   base.EnterState();
    //   characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE_SIDE);
    // }

    protected override void EnterState()
    {
        base.EnterState();

        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE_SIDE);
    }
}