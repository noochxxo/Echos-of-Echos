using Godot;

public partial class Camera : Camera3D
{
  [Export] private Node target;
  [Export] private Vector3 positionFromTarget;

    public override void _Ready()
    {
        
        GameEvents.OnStartGame += HandleStartGame;
        GameEvents.RaiseStartGame();
    }

    private void HandleStartGame()
    {
        Reparent(target);
        Position = positionFromTarget;
    }
}