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
			var textos = JsonConvert.DeserializeObject<List<Dialog>>(parametro);
			var laSalle = GetNode<CharacterCTRL>("./LaSalle");
			var violet = GetNode<CharacterCTRL>("./Violet");
			GUI.PopularDialogos(textos, laSalle, violet);
		}
		catch (Exception ex)
		{
			GUI.SetarTexto(ex.Message);
		}
	}
	private string ObterParametro()
	{
		var parametro = JavaScript.Eval("new URLSearchParams(window.location.search).get('json')")?.ToString();
		var a = parametro.Replace("\"[", "[");
		var b = a.Replace("]\"", "]");
		var c = b.Replace("\\", "");
		return c;
	}
	private void _on_Camera_EncontrouAvatar(string itemCode)
	{
		GUI.Visible = true;
	}
}
