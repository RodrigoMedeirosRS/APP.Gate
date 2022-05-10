using Godot;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

using DTO;

public class MainCTRL : Spatial
{
	private List<Dialog> Textos { get; set; }
	private GUICTRL GUI { get; set; }
	public override void _Ready()
	{
		PopularNodes();
		ObterTextos();
	}

	private void PopularNodes()
	{
		GUI = GetNode<GUICTRL>("./GUI");
		GUI.Visible = false;
	}

	private void ObterTextos()
	{
		try
		{
			var parametro = ObterParametro();
			var a = parametro.Replace("\"[", "[");
			var b = a.Replace("]\"", "]");
			var c = b.Replace("\\", "");
			//GUI.SetarTexto("Sucesso");
			var textos = JsonConvert.DeserializeObject<List<Dialog>>(c);
			GUI.SetarTexto("Sucesso");
		}
		catch (Exception ex)
		{
			GUI.SetarTexto(ex.Message);
		}
	}
	private string ObterParametro()
	{
		return JavaScript.Eval("new URLSearchParams(window.location.search).get('json')")?.ToString();
	}
	private void CarregarArquivo()
	{
		var file = new Godot.File();
		file.Open("res://save_game.dat", File.ModeFlags.Read);
		file.GetPathAbsolute();
		var content = file.GetAsText();
		GUI.SetarTexto(file.GetPathAbsolute());
		file.Close();
	}

	private void CriarPasta()
	{
		var file = new File();
		file.Open("res://save_game.dat", File.ModeFlags.Write);
		file.StoreString("Arquivo Teste");
		GUI.SetarTexto(file.GetPathAbsolute());
		file.Close();
	}
	private void _on_Camera_EncontrouAvatar(string itemCode)
	{
		GUI.Visible = true;
	}
}
