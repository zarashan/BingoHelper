using System;
using System.Collections.Generic;
using BingoHelper.BingoFiles;
using Godot;

namespace BingoHelper;

public partial class MainController : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetWindow().FilesDropped += DroppedFile;

		GetNode<Button>("HBoxContainer/View").ButtonUp += ChangeView;
		GetNode<Button>("HBoxContainer/Generate").ButtonUp += GenerateBoard;
		GetNode<Button>("HBoxContainer/Quit").ButtonUp += () => { GetTree().Quit();};

	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void DroppedFile(string[] files)
	{
		foreach (var file in files)
		{
			GD.Print(file);
			
		}
	}
	
	private void ChangeView()
	{
		
	}

	public void GenerateBoard()
	{
		var BingoBoard = new List<BingoItem>();
		var rand = new Random(DateTime.Now.GetHashCode());

		var types = Enum.GetValues<BingoTypes>();
		var SizeTypes = new[]
		{
			Enum.GetValues<CollectionType>().Length,
			Enum.GetValues<WierdType>().Length,
			Enum.GetValues<KillType>().Length,
			Enum.GetValues<SceneType>().Length,
		};


		while (BingoBoard.Count < 25)
		{
			var type = types[rand.Next(types.Length)];

			switch (type)
			{
				case BingoTypes.Collection:
					BingoBoard.Add(BingoItem.GenerateCollection(rand));
					break;
				case BingoTypes.Wierd:
					BingoBoard.Add(BingoItem.GenerateWierd(rand));
					break;
				case BingoTypes.Kill:
					BingoBoard.Add(BingoItem.GenerateKill(rand));
					break;
				case BingoTypes.Scene:
					BingoBoard.Add(BingoItem.GenerateScene(rand));
					break;
			}
		}

		ShowBingoBoard(BingoBoard);
	}

	private void ShowBingoBoard(List<BingoItem> bingoBoard)
	{
		
	}
}