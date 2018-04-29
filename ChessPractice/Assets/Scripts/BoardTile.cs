using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
   [SerializeField] bool TileOccupied = false;

    public bool GetTileOccupied()
    {
        return TileOccupied;
    }

    public void SetTileOccupied(bool state)
    {
        TileOccupied = state;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Piece")
        {
            TileOccupied = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Piece")
        {
            TileOccupied = false;
        }
    }

    private void OnMouseDown()
    {
        if (!TileOccupied)
        {
            GetComponentInParent<BoardManager>().UpdateSelectedTile(this);
        }
       
    }

}
