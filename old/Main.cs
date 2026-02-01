using Godot;
using System;

public partial class Main : Node2D
{
	Role1 role;
	// 当节点首次进入场景树时调用。
	public override void _Ready()
	{
		// 获取角色节点
		role = GetNode<Role1>("Node2D/Sprite2D");

		role.HealthDepleted += OnHealthDepleted;
	}

	private void OnHealthDepleted()
	{
		GD.Print("Health depleted" + role.Health);
	}

	// 每帧调用。'delta' 是自上一帧以来经过的时间。
	public override void _Process(double delta)
	{
		Console.WriteLine("Hello World!");

	}
}
