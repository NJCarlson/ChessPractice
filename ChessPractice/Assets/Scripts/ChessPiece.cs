using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour {

    public enum Piece {Pawn = 0, Knight = 1, Rook = 2, Bishop = 3, Queen = 4, King = 5};
    [SerializeField] Piece Type;
     public BoardTile BoardPos;

    [SerializeField] Camera MainCam;
    private Vector3 screenPoint;
    private Vector3 offset;
    private BoardManager BoardMan;
    private bool DestroyFlag = false;

    public int getPieceType()
    {
        return (int) Type;
    }

    public void SetDestroyFlag(bool flag)
    {
        DestroyFlag = flag;
    }

    private void Update()
    {
        if (DestroyFlag)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        DestroyFlag = false;
        MainCam = GameObject.FindObjectOfType<Camera>();
        BoardMan = GameObject.FindObjectOfType<BoardManager>();
    }
    void OnMouseDown()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        screenPoint = MainCam.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        //if (BoardPos != null)
        //{
        //    BoardPos.SetTileOccupied(false);
        //    BoardPos = null;
        //}
        
       
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

   public void OnMouseDrag()
    {
        BoardMan.UpdateSelectedPiece(this);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = MainCam.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Tile")
       {
            BoardTile Temp = collision.collider.gameObject.GetComponent<BoardTile>() ;
            
            
            BoardMan.MakeMove(Temp, this);
            BoardPos = Temp;

          //  if (!Temp.GetTileOccupied())
          //  {
                //transform.position = collision.collider.gameObject.transform.position;
               // BoardPos = collision.collider.gameObject.GetComponent<BoardTile>();
          //  }
           
        }
        //else
        //{
        //    Destroy(this.gameObject);
        //}
       
    }

}
