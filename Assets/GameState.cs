using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static Transform[,] chessboard = new Transform[8,8];
    public GameObject originalSquare;
    public Transform chessboardParent;
    public Transform chessPieces;
    const int SQUARE_SIZE = 2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                GameObject square = Instantiate(originalSquare, chessboardParent);
                square.GetComponent<Square>().i = i;
                square.GetComponent<Square>().j = j;
                square.transform.position = new Vector3(i * SQUARE_SIZE - SQUARE_SIZE * 3.5f, 1.8f, j * SQUARE_SIZE - SQUARE_SIZE * 3.5f);

                for (int k = 0; k < chessPieces.childCount; ++k)
                {
                    if (Vector3.Distance(chessPieces.GetChild(k).position, square.transform.position) < SQUARE_SIZE/2)
                    {
                        square.GetComponent<Square>().piece = chessPieces.GetChild(k);
                    }
                }
                square.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.0f);

                chessboard[i, j] = square.transform;
            }
        }

        Destroy(originalSquare);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
