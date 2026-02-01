using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

	// 游戏窗口的大小。
	public Vector2 ScreenSize;

	private AnimatedSprite2D animatedSprite2D;

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	public override void _Process(double delta)
	{
		// 玩家的移动向量。
		var velocity = Vector2.Zero;


		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		Position += velocity * (float)delta;
		// 防止玩家离开屏幕。
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
		// Clamp 函数的作用是:将一个值限制在指定的范围内。
		// 这里的作用是防止玩家离开屏幕。

	}
}
