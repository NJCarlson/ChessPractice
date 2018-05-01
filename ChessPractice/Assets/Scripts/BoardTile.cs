using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
   [SerializeField] bool TileOccupied = false;
    public ChessPiece mPiece;

    public bool GetTileOccupied()
    {
        return TileOccupied;
    }

    public ChessPiece getPiece()
    {
        return mPiece;
    }

    public void ClearPiece()
    {
        mPiece.SetDestroyFlag(true);
        mPiece = null;
        TileOccupied = false;
    }

    public void SetTileOccupied(bool state, ChessPiece Piece)
    {
        TileOccupied = state;

        if (state)
        {
            mPiece = Piece;
        }
        else
        {
            mPiece = null;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Piece")
    //    {
    //        TileOccupied = true;
    //    }
    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //    if (collision.collider.tag == "Piece")
    //    {
    //        TileOccupied = false;
    //    }
    //}



    // highlights clicked tile
    private void OnMouseDown()
    {
        if (!TileOccupied)
        {
            GetComponentInParent<BoardManager>().UpdateSelectedTile(this);
        }
       
    }

}
