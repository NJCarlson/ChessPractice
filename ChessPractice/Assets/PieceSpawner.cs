using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour {

    [SerializeField] GameObject nPiece;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Piece")
        {
            Instantiate(nPiece);
        }
    }


}
