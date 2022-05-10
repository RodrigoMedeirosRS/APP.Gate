using Godot;
using System;
using System.Collections.Generic;

using DTO;

public class GUICTRL : Control
{
	private List<Dialog> Dialogos { get; set; }
	private Node Dialogo { get; set; }
	private Node Narrativa { get; set; }
	private Label Texto { get; set; }
	public override void _Ready()
	{
		Narrativa = GetNode<Node>("./Narrativa");
		Dialogo = GetNode<Node>("./Dialogo");
		Texto = GetNode<Label>("./Narrativa/Label");
	}
	public void TestarLista()
	{
		if (Dialogos == null)
			Texto.Text = "Não pegou";
		else
			Texto.Text = "Pegou";
	}
	public void SetarTexto(string text)
	{
		Texto.Text = text;
	}
	public void PopularDialogos(List<Dialog> dialogos)
	{
		Dialogos = new List<Dialog>();
		Dialogos = dialogos;
		TestarLista();
	}
	private void _on_Button1_button_up()
	{
		// Replace with function body.
	}
	private void _on_Button2_button_up()
	{
		// Replace with function body.
	}
	private void _on_Button3_button_up()
	{
		// Replace with function body.
	}
	private void _on_Button4_button_up()
	{
		// Replace with function body.
	}
}
