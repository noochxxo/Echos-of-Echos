using System;
using Godot;

public abstract partial class CharacterState : Node
{
  // [Signal]
  // public delegate void StateEnteredEventHandler();
  // [Signal]
  // public delegate void StateExitedEventHandler();
  

  protected Character characterNode;
  public Func<bool> CanTransition = () => true;

    public override void _Ready()
    {
        characterNode = GetOwner<Character>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

  // public virtual void EnterState()
  // {
  //   EmitSignal(SignalName.StateEntered);
  //   SetPhysicsProcess(true);
  //           SetProcessInput(true);
  //   Console.WriteLine("Entered State");
  // }

  // public virtual void ExitState()
  // {
  //   EmitSignal(SignalName.StateExited);
  //   SetPhysicsProcess(false);
  //           SetProcessInput(false);
  //   Console.WriteLine("Exited State");
  // }
  public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == GameConstants.NOTIFICATION_ENTER_STATE)
        {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == GameConstants.NOTIFICATION_EXIT_STATE)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);

            ExitState();
        }
    }

    protected virtual void EnterState() { }
    protected virtual void ExitState() { }
}
