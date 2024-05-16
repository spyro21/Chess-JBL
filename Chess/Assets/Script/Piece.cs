using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public string pieceType;
    public (int x, int y) position;
    public int team;

    public Piece(int team, string pieceType, (int x, int y) position)
    {
        this.pieceType = pieceType;
        this.position = position;
        this.team = team;
    }

    void start() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

    }

    
}
