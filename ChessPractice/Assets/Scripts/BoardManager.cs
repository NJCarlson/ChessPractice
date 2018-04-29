using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    //Tile Info
    BoardTile[] Tiles;
    BoardTile SelectedTile;
    [SerializeField] Color SelectedTileColor;
    private Color PrevTileColor;

    ChessPiece[] PiecesOnBoard;
    ChessPiece SelectedPiece;
    [SerializeField] Color SelectedPieceColor;
    private Color PrevPieceColor;



    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void AddPieceToBoard()
    {
        //TODO: Add piece to the array of pieces on board 
    }

    void RemovePieceFromBoard()
    {
        //TODO: Remove Piece from the array of pieces on board
    }

    public void UpdateSelectedPiece(ChessPiece newPiece)
    {
        // if there is a selected tile
        if (SelectedPiece != null)
        {
            //Set previously selected tile color back
            SelectedPiece.GetComponent<SpriteRenderer>().color = PrevTileColor;
        }

        //update PrevColor to the newSelected Color
        PrevPieceColor = newPiece.GetComponent<SpriteRenderer>().color;

        //update selected tile & highlight
        SelectedPiece = newPiece;
        SelectedPiece.GetComponent<SpriteRenderer>().color = SelectedTileColor;
    }

    public void UpdateSelectedTile(BoardTile newSelected)
    {
        // if there is a selected tile
        if (SelectedTile != null)
        {
            //Set previously selected tile color back
             SelectedTile.GetComponent<SpriteRenderer>().color = PrevTileColor;
        }
      
        //update PrevColor to the newSelected Color
        PrevTileColor = newSelected.GetComponent<SpriteRenderer>().color;

        //update selected tile & highlight
        SelectedTile = newSelected;
        SelectedTile.GetComponent<SpriteRenderer>().color = SelectedTileColor;
    }

    public void MoveButton()
    {
        //TODO:
        // move selected piece to selected tile
        // Clear selected tiles and Pieces; 
    }
   
}
