using Godot;
using System;

// partial 是干嘛的？
// 它可以将一个类分成多个文件，每个文件都可以有自己的代码。
// 这样做的好处是可以使代码更加清晰， easier to read and maintain.


public partial class Mob : RigidBody2D
{
	// ["walk", "swim", "fly"]
	AnimatedSprite2D animatedSprite2D;
	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		string[] mobTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();
		animatedSprite2D.Play(mobTypes[GD.Randi() % mobTypes.Length]);
	}

	public override void _Process(double delta)
	{

	}

	// We also specified this function name in PascalCase in the editor's connection window.
	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
