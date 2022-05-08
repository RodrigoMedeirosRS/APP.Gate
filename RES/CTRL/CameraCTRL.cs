using Godot;
using System;

public class CameraCTRL : Camera
{
  private float MinLookAngle { get; set; }
  private float MaxLookAngle { get; set; }
  private float LookSensitivity { get; set; }
	
  private void popularNodes()
  {
	  MinLookAngle = -90f;
	  MaxLookAngle = 90f;
	  LookSensitivity = 0.005f;
  }
  public override void _Ready()
  {
	  popularNodes();
   
  }

  public override void _Process(float delta)
  {
	  if(Input.IsActionPressed("ui_accept"))
		  Input.SetMouseMode(Input.MouseMode.Captured);
	  else
		  Input.SetMouseMode(Input.MouseMode.Visible);
  }
  public override void _Input(InputEvent movimento) 
  {
	  var movimentoMouse = movimento as InputEventMouseMotion;
	  var movimentoTela = movimento as InputEventScreenDrag;
	  if (movimentoMouse != null && Input.IsActionPressed("ui_accept")) 
	  {
	  //var x = Mathf.Clamp(movimentoMouse.Relative.y * LookSensitivity, MinLookAngle, MaxLookAngle);
	  	this.Rotation -= new Vector3(movimentoMouse.Relative.y * LookSensitivity, movimentoMouse.Relative.x * LookSensitivity, 0);
	  }
	else if (movimentoTela != null)
	{
	  this.Rotation += new Vector3(movimentoTela.Relative.y * LookSensitivity, movimentoTela.Relative.x * LookSensitivity, 0);
	}
  } 
}
