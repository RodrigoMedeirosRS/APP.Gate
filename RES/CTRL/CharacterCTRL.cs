using Godot;
using System;

public class CharacterCTRL : Spatial
{
	private AnimationPlayer Animacao { get; set; }
	public override void _Ready()
	{
		PopularNodes();
	}
	private void PopularNodes()
	{
		Animacao = GetNode<AnimationPlayer>("./AnimationPlayer");
	}
	public void Animar(bool falar)
	{
		if (falar)
			Animacao.Play("Talk");
		else
			Animacao.Play("Idle");
	}
}
