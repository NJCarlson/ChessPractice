using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    //Tile Info
    List<BoardTile[]> BoardStates;
   [SerializeField] BoardTile[] CurrentBoardTiles;
    BoardTile SelectedTile;
    [SerializeField] Color SelectedTileColor;
    private Color PrevTileColor;

    //ChessPiece[] PiecesOnBoard;
    ChessPiece SelectedPiece;
    [SerializeField] Color SelectedPieceColor;
    private Color PrevPieceColor;
    
    [SerializeField] BoardTile[] DefaultBoardStateBlackTop;
    

    [SerializeField] BoardTile[] DefaultBoardStateWhiteTop;
   

    [SerializeField] GameObject spawnPoint;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void ResetButton()
    {
        PopulateBoard(DefaultBoardStateBlackTop);
        //reset saved states
    }

    public void PopulateBoard(BoardTile[] board )
    {
        ClearBoard();
        ChessPiece tPiece;

        for (int i = 0; i < board.Length; i++)
        {
            if (board[i].GetTileOccupied() && board[i].getPiece() != null)
            {
               
                tPiece = Instantiate(board[i].getPiece(), spawnPoint.transform);
                tPiece.gameObject.transform.position = board[i].transform.position;
              //  MakeMove(board[i], tPiece);
            }
            else
            {
                tPiece = null;
            }

            CurrentBoardTiles[i].SetTileOccupied(board[i].GetTileOccupied(), tPiece);
        }
    }

    //destroys all pieces off of board, but does not reset CurrentBoardTiles[], or BoardStates;
    public void ClearBoard()
    {
        for (int i = 0; i < CurrentBoardTiles.Length; i++)
        {
            if (CurrentBoardTiles[i].GetTileOccupied() && CurrentBoardTiles[i].getPiece() != null )
            {
                CurrentBoardTiles[i].ClearPiece();               
            }
        }

    }

    public void KingsOnly()
    {
        for (int i = 0; i < CurrentBoardTiles.Length; i++)
        {
            if (CurrentBoardTiles[i].GetTileOccupied() && CurrentBoardTiles[i].getPiece() != null && CurrentBoardTiles[i].getPiece().getPieceType() != 5)
            {
                CurrentBoardTiles[i].ClearPiece();
            }
        }

    }

    public void MakeMove(BoardTile NewLoc, ChessPiece Piece)
    {
      //  Piece.
        if (NewLoc.GetTileOccupied() && NewLoc.getPiece() != null && NewLoc.getPiece() != Piece )
        {
            NewLoc.ClearPiece();
        }

        if (Piece.BoardPos != null && Piece.BoardPos.GetTileOccupied() ) // if the old tile was occupied, clear it
        {
            Piece.BoardPos.SetTileOccupied(false, null); // clear old tile's tile occupied bool
        }
       
        Piece.transform.position = NewLoc.gameObject.transform.position;
        NewLoc.SetTileOccupied(true, Piece);

    }

    public void MoveButton()
    {
        MakeMove(SelectedTile, SelectedPiece);
        //TODO:
        // Clear selected tiles and Pieces; 
    }

    public void UpdateSelectedPiece(ChessPiece newPiece)
    {
        // if there is a selected tile
        if (SelectedPiece != null)
        {
            //Set previously selected tile color back
            SelectedPiece.GetComponent<SpriteRenderer>().color = PrevPieceColor;
        }

        //update PrevColor to the newSelected Color
        PrevPieceColor = newPiece.GetComponent<SpriteRenderer>().color;

        //update selected tile & highlight
        SelectedPiece = newPiece;
        SelectedPiece.GetComponent<SpriteRenderer>().color = SelectedPieceColor;
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

    
   
}
