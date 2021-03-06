	using Godot;
	using System;

public class CameraCTRL : Camera
{
	[Signal]
	public delegate void EncontrouAvatar(string itemCode);

	private float MinLookAngle { get; set; }
	private float MaxLookAngle { get; set; }
	private float LookSensitivity { get; set; }
	private RayCast Sensor { get; set; }
	private bool Interecao { get; set; }
			
	private void PopularNodes()
	{
		MinLookAngle = -90f;
		MaxLookAngle = 90f;
		LookSensitivity = 0.005f;
		Sensor = GetNode<RayCast>("./RayCast");
		Interecao = false;
	}
		
	public override void _Ready()
	{
		PopularNodes();
	}

	public override void _Process(float delta)
	{
		MoverCamera();
	}
	
	public override void _PhysicsProcess(float delta)
	{
		ExibirDialogo();
	}

	private void MoverCamera()
	{
		if(!Interecao)
		{
			if (Input.IsActionPressed("ui_accept"))
				Input.SetMouseMode(Input.MouseMode.Captured);
			else
				Input.SetMouseMode(Input.MouseMode.Visible);
		}
		else if (Input.GetMouseMode() == Input.MouseMode.Captured)
		{
			Input.SetMouseMode(Input.MouseMode.Visible);
		}
	}

	private void ExibirDialogo()
	{
		if (!Interecao)
		{
			var colisor = Sensor.GetCollider();
			if(colisor != null)
			{
				Interecao = true;
				EmitSignal("EncontrouAvatar", (colisor as Node).Name);
			}
		}
	}
	public override void _Input(InputEvent movimento) 
	{
		if(!Interecao)
		{
			var movimentoMouse = movimento as InputEventMouseMotion;
			var movimentoTela = movimento as InputEventScreenDrag;
				
			if (movimentoMouse != null && Input.IsActionPressed("ui_accept")) 
			{
				this.Rotation -= new Vector3(movimentoMouse.Relative.y * LookSensitivity, movimentoMouse.Relative.x * LookSensitivity, 0);
			}
			else if (movimentoTela != null)
			{
				this.Rotation += new Vector3(movimentoTela.Relative.y * LookSensitivity, movimentoTela.Relative.x * LookSensitivity, 0);
			}
		}
	} 
}
