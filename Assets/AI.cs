using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    string ai_player = "Black";
    List<Transform> aiPieces = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("piece")) {
            if (t.name.Contains(ai_player))
                aiPieces.Add(t.transform);
        }
    }

    void makeRandomMove()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!GameState.playersTurn)
        {
            makeRandomMove();
        }
    }
}
