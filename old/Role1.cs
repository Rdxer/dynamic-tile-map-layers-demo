using Godot;
using System;

public partial class Role1 : Sprite2D
{

	private int _speed = 40;
	private float _angularSpeed = Mathf.Pi;
	Role1()
	{
		GD.Print("Hello, world!");
	}
	// 当节点首次进入场景树时调用。
	public override void _Ready()
	{
		GD.Print("Role1 _Ready");
		var timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
	}

	private void OnTimerTimeout()
	{
		GD.Print("Timer timeout");
		Visible = !Visible;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent)
		{
			if (keyEvent.Pressed)
			{
				GD.Print($"Key pressed: {keyEvent.Keycode}");
				if (keyEvent.Keycode == Key.Space)
				{
					TakeDamage(1);
				}
			}
		}
	}

	// 每帧调用。'delta' 是自上一帧以来经过的时间。
	public override void _Process(double delta)
	{


		//Rotation += _angularSpeed * (float)delta;


		var direction = 0;
		if (Input.IsActionPressed("ui_left"))
		{
			direction = -1;
		}
		if (Input.IsActionPressed("ui_right"))
		{
			direction = 1;
		}

		// 计算旋转角度
		Rotation += _angularSpeed * direction * (float)delta;


		var velocity = Vector2.Zero;
		if (Input.IsActionPressed("ui_up"))
		{
			velocity = Vector2.Right.Rotated(Rotation) * _speed;
		}

		if (Input.IsActionPressed("ui_down"))
		{
			velocity = Vector2.Left.Rotated(Rotation) * _speed;
		}

		Position += velocity * (float)delta;
	}
	public void OnButtonPressed()
	{
		GD.Print("Button pressed");
		SetProcess(!IsProcessing());
	}

	[Signal]
	public delegate void HealthDepletedEventHandler();

	private int _health = 10;
	public int Health => _health;

	public void TakeDamage(int amount)
	{
		_health -= amount;

		if (_health <= 0)
		{
			EmitSignal(SignalName.HealthDepleted);
		}
	}
}
