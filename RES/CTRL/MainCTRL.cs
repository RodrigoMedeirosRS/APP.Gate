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
		GUI.PopularDialogos(null);
		if(System.IO.File.Exists("./dialogue.json"))
		{
			var texto = System.IO.File.ReadAllText("./dialogue.json");
			var dialogs = JsonConvert.DeserializeObject<List<Dialog>>(texto);
			GUI.PopularDialogos(dialogs);
		}
	}

	private void _on_Camera_EncontrouAvatar(string itemCode)
	{
		GUI.Visible = true;
	}
}