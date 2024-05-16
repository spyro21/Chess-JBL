using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessControl : MonoBehaviour
{
    public GameObject piecePrefab;
    ChessModels model;
    public GameObject piecesObject;

    Piece[] pieces = {
        new Piece(0,"rook", (0, 0)),
        new Piece(0,"knight", (1, 0)),
        new Piece(0,"bishop", (2, 0)),
        new Piece(0,"queen", (3, 0)),
        new Piece(0,"king", (4, 0)),
        new Piece(0,"bishop", (5, 0)),
        new Piece(0,"knight", (6, 0)),
        new Piece(0,"rook", (7, 0)),
        new Piece(0,"pawn", (0, 1)),
        new Piece(0,"pawn", (1, 1)),
        new Piece(0,"pawn", (2, 1)),
        new Piece(0,"pawn", (3, 1)),
        new Piece(0,"pawn", (4, 1)),
        new Piece(0,"pawn", (5, 1)),
        new Piece(0,"pawn", (6, 1)),
        new Piece(0,"pawn", (7, 1)),
        new Piece(1,"rook", (0, 7)),
        new Piece(1,"knight", (1, 7)),
        new Piece(1,"bishop", (2, 7)),
        new Piece(1,"queen", (3, 7)),
        new Piece(1,"king", (4, 7)),
        new Piece(1,"bishop", (5, 7)),
        new Piece(1,"knight", (6, 7)),
        new Piece(1,"rook", (7, 7)),
        new Piece(1,"pawn", (0, 6)),
        new Piece(1,"pawn", (1, 6)),
        new Piece(1,"pawn", (2, 6)),
        new Piece(1,"pawn", (3, 6)),
        new Piece(1,"pawn", (4, 6)),
        new Piece(1,"pawn", (5, 6)),
        new Piece(1,"pawn", (6, 6)),
        new Piece(1,"pawn", (7, 6))
    };

    // Start is called before the first frame update
    void Start()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<ChessModels>();
        //setup start
        setupStart();
    }

    void setupStart() {
        for(int i = 0; i < pieces.Length; i++) {
            instantiatePiece(i);
        }
    }
    
    void instantiatePiece(int i) {
        GameObject newPiece = Instantiate(piecePrefab, new Vector3(pieces[i].position.x, pieces[i].position.y, 0), Quaternion.identity);
            Piece newPieceScript = newPiece.GetComponent<Piece>();
            newPieceScript = pieces[i];
            if(newPieceScript.team == 0) {
                switch(newPieceScript.pieceType) {
                    case "rook":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.wR;
                        break;
                    
                    case "knight":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.wN;
                        break;
                    
                    case "bishop":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.wB;
                        break;
                    
                    case "queen":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.wQ;
                        break;
                    
                    case "king":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.wK;
                        break;

                    case "pawn":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.wP;
                        break;
                }
            } else {
                switch(newPieceScript.pieceType) {
                    case "rook":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.bR;
                        break;
                    
                    case "knight":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.bN;
                        break;
                    
                    case "bishop":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.bB;
                        break;
                    
                    case "queen":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.bQ;
                        break;
                    
                    case "king":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.bK;
                        break;

                    case "pawn":
                        newPiece.GetComponent<SpriteRenderer>().sprite = model.bP;
                        break;
                }
            }
            

            newPiece.transform.parent = piecesObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
