using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece : MonoBehaviour
{
    public const int WHITE = 0;
    public const int BLACK = 1; 

    public const int PAWN = 0;
    public const int BISHOP = 1;
    public const int KNIGHT = 2;
    public const int ROOK = 3;
    public const int QUEEN = 4;
    public const int KING = 5;

    public int pieceType;
    public (int x, int y) position;
    public int team;
    public bool hasMoved;

    public Piece(int team, int pieceType)
    {
        this.pieceType = pieceType;
        this.position = ((int) transform.position.x, (int) transform.position.y);
        this.team = team;
        hasMoved = false;
    }

    void Start() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        this.position = ((int)transform.position.x, (int)transform.position.y);
    }

    
}
