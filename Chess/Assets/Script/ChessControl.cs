using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ChessControl : MonoBehaviour
{
    public GameObject piecePrefab;
    ChessModels model;

    public Piece[] pieces;

    // Start is called before the first frame update
    void Start()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<ChessModels>();
    }
    
    
    public bool checkPosition(Piece piece, Vector3 newPosition, Vector3 prevPosition) {
        //check if position is in bounds
        if(!checkBoardBoundaries(piece, newPosition, prevPosition)) return false;
        if(!checkLegalPieceMove(piece, newPosition, prevPosition)) return false;

        return true;
    }

    private bool checkBoardBoundaries(Piece piece, Vector3 newPosition, Vector3 prevPosition) {
        return !(newPosition.x > 7 || newPosition.x < 0 || newPosition.y > 7 || newPosition.y < 0);
    }

    private bool checkLegalPieceMove(Piece piece, Vector3 newPosition, Vector3 prevPosition) {
        int pieceType = piece.pieceType;
        
        switch(pieceType) {
            case Piece.PAWN:
                float yDistance = newPosition.y - prevPosition.y;
                if(newPosition.x != prevPosition.x) {
                    Debug.Log(newPosition.x - prevPosition.x);
                    if(math.abs(newPosition.x - prevPosition.x) != 1) return false;
                    if(piece.team == Piece.WHITE && yDistance != 1) return false;
                    if(piece.team == Piece.BLACK && yDistance != -1) return false;

                    Piece attackedPiece = getPieceFromPosition(((int) newPosition.x, (int) newPosition.y));
                    Debug.Log(attackedPiece);
                    return attackedPiece != null && attackedPiece.team != piece.team;
                }
                
                if(!piece.hasMoved) {
                    if(piece.team == Piece.WHITE && yDistance != 2 && yDistance != 1) return false;
                    if(piece.team == Piece.BLACK && yDistance != -2 && yDistance != -1) return false;

                    if(piece.team == Piece.WHITE && yDistance == 2) {
                        if(isPiecePresent((int) prevPosition.x, (int) prevPosition.y + 1) || isPiecePresent((int) prevPosition.x, (int) prevPosition.y + 2)) return false;
                    }
                    if(piece.team == Piece.BLACK && yDistance == -2) {
                        if(isPiecePresent((int) prevPosition.x, (int) prevPosition.y - 1) || isPiecePresent((int) prevPosition.x, (int) prevPosition.y - 2)) return false;
                    }

                    if(piece.team == Piece.WHITE && yDistance == 1) {
                        if(isPiecePresent((int) prevPosition.x, (int) prevPosition.y + 1)) return false;
                    }
                    if(piece.team == Piece.BLACK && yDistance == -1) {
                        if(isPiecePresent((int) prevPosition.x, (int) prevPosition.y - 1)) return false;
                    }
                } else {
                    if(piece.team == Piece.WHITE && piece.hasMoved && yDistance != 1) return false;
                    if(piece.team == Piece.BLACK && piece.hasMoved && yDistance != -1) return false;

                    if(piece.team == Piece.WHITE) {
                        if(isPiecePresent((int) prevPosition.x, (int) prevPosition.y + 1)) return false;
                    }
                    if(piece.team == Piece.BLACK) {
                        if(isPiecePresent((int) prevPosition.x, (int) prevPosition.y - 1)) return false;
                    }
                }
                //TODO: PATHS
                //TODO: TAKES
                break;
            case Piece.BISHOP:

                break;
            case Piece.KNIGHT:

                break;
            case Piece.ROOK:

                break;
            case Piece.QUEEN:

                break;
            case Piece.KING:

                break;
        }

        return true;
    }

    public void movePiece(Piece piece, Vector3 newPosition) {
        Piece piecePresent = getPieceFromPosition(((int) newPosition.x,(int) newPosition.y));

        if(piecePresent && piece.team != piecePresent.team) {
            //remove piece
        }

        piece.position.x = (int) newPosition.x;
        piece.position.y = (int) newPosition.y;
        piece.hasMoved = true;

        //TODO: check for win condition
    }

    private bool isPiecePresent(int x, int y) {
        return getPieceFromPosition((x, y)) != null;
    }

    private Piece getPieceFromPosition((int x, int y) position) {
        foreach(Piece piece in pieces) {
            if(piece.position.x == position.x && piece.position.y == position.y) {
                return piece;
            }
        }
        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
