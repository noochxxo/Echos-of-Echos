using Godot;
using System;
public abstract partial class Character : CharacterBody3D
{
  [ExportGroup("Required Modes")]
  [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
  [Export] public Sprite3D SpriteNode { get; private set; }
  [Export] public StateMachine StateMachineNode { get; private set; }
  [Export] public CollisionShape3D Collider { get; private set; }
  public Vector2 direction = new();
 
  public void Flip()
  {
    bool isNotMovingHorizontally = Velocity.X == 0;
    if (isNotMovingHorizontally) return;
    bool isMovingLeft = Velocity.X < 0;
    SpriteNode.FlipH = isMovingLeft;
    if (isMovingLeft) {
      Collider.Position = new Vector3(0,0,0);
    } else {
      Collider.Position = new Vector3(1,0,0);
    }
  }

}