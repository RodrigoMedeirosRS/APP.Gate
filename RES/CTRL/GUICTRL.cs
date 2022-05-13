using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

using DTO;

public class GUICTRL : Control
{
	private List<Dialog> Dialogos { get; set; }
	private Dialog DialogoAtual { get; set; }
	private Control Dialogo { get; set; }
	private Control Narrativa { get; set; }
	private Label Texto { get; set; }
	private List<Button> Botoes { get; set; }
	private CharacterCTRL LaSalle { get; set; }
	private CharacterCTRL Violet { get; set; }
	public override void _Ready()
	{
		Narrativa = GetNode<Control>("./Narrativa");
		Dialogo = GetNode<Control>("./Dialogo");
		Texto = GetNode<Label>("./Narrativa/Label");
		Botoes = new List<Button>();
		foreach (var botao in GetNode<VBoxContainer>("Dialogo/VBoxContainer").GetChildren())
			Botoes.Add(botao as Button);
	}
	public void PopularDialogos(List<Dialog> dialogos, CharacterCTRL laSalle, CharacterCTRL violet)
	{
		Dialogos = new List<Dialog>();
		LaSalle = laSalle;
		Violet = violet;
		Dialogos = dialogos;
		ValidarTipoDialogo(Dialogos[0]);
	}
	private void ValidarTipoDialogo(Dialog dialogo)
	{
		if (dialogo.Type == "Text")
			InstanciarDialogoNarrativo(dialogo);
		else
			InstanciarDialogoEscolha(dialogo);
	}
	private void InstanciarDialogoNarrativo(Dialog dialogo)
	{
		if(dialogo.Actor == "Violet")
		{
			Violet.Visible = true;
			LaSalle.Visible = false;
		}
		else
		{
			Violet.Visible = false;
			LaSalle.Visible = true;
		}
		Violet.Animar(true);
		LaSalle.Animar(true);
		Narrativa.Visible = true;
		Dialogo.Visible = false;
		DialogoAtual = dialogo;
		SetarTexto(dialogo.Name);
	}
	public void SetarTexto(string text)
	{
		Texto.Text = text;
	}
	private void InstanciarDialogoEscolha(Dialog dialogo)
	{
		Violet.Animar(false);
		LaSalle.Animar(false);
		Narrativa.Visible = false;
		Dialogo.Visible = true;
		DialogoAtual = dialogo;
		SetarOpcoes(dialogo.Branches);
	}
	public void SetarOpcoes(Dictionary<string, string> opcoes)
	{
		foreach(var button in Botoes)
			button.Visible = false;
		for(int i = 0; i < opcoes.Count; i++)
		{
			Botoes[i].GetChild<Label>(0).Text = opcoes.ElementAt(i).Key;
			Botoes[i].Visible = true;
		}
	}
	public Dialog ObterProxioDialogo(string idDialogo)
	{
		return Dialogos.FirstOrDefault(dialog => dialog.Id == idDialogo);
	}
	private void _on_Button1_button_up()
	{
		var proximoDialogo = ObterProxioDialogo(DialogoAtual.Branches.ElementAt(0).Value);
		ValidarTipoDialogo(proximoDialogo);
	}
	private void _on_Button2_button_up()
	{
		var proximoDialogo = ObterProxioDialogo(DialogoAtual.Branches.ElementAt(1).Value);
		ValidarTipoDialogo(proximoDialogo);
	}
	private void _on_Button3_button_up()
	{
		var proximoDialogo = ObterProxioDialogo(DialogoAtual.Branches.ElementAt(2).Value);
		ValidarTipoDialogo(proximoDialogo);
	}
	private void _on_Button4_button_up()
	{
		var proximoDialogo = ObterProxioDialogo(DialogoAtual.Branches.ElementAt(3).Value);
		ValidarTipoDialogo(proximoDialogo);
	}
	private void _on_Continuar_button_up()
	{
		var proximoDialogo = ObterProxioDialogo(DialogoAtual.Next);
		ValidarTipoDialogo(proximoDialogo);
	}
}
