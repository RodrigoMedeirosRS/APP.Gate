using Godot;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

using DTO;

public class MainCTRL : Spatial
{
	private List<Dialog> Textos { get; set; }
	private GUICTRL GUI { get; set; }
	public override void _Ready()
	{
		ObterTextos();
		PopularNodes();
	}

	private void PopularNodes()
	{
		GUI = GetNode<GUICTRL>("./GUI");
		GUI.Visible = false;
	}

	private void ObterTextos()
	{
		var json = System.IO.File.Exists("./dialogue.json");
		var text = System.IO.File.ReadAllText("./dialogue.json");
		var texto = JsonConvert.DeserializeObject<List<Dialog>>(text);
	}

	private void _on_Camera_EncontrouAvatar(string itemCode)
	{
		GUI.Visible = true;
	}
}