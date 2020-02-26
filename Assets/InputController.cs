using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
 
    Transform selectedPiece;
    Transform selectedSquare;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void selectSquare(Transform square)
    {
        deselectSquare();
        selectedSquare = square;
        selectedSquare.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
    }

    void deselectSquare()
    {
        if (selectedSquare)
        {
            selectedSquare.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
    }

    void selectPiece(Transform piece)
    {
        deselectPiece();
        selectedPiece = piece;

        Renderer[] renderers = selectedPiece.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", Color.red);
        }
    }

    void deselectPiece()
    {
        if (selectedPiece)
        {
            Renderer[] renderers = selectedPiece.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.material.DisableKeyword("_EMISSION");
                r.material.SetColor("_EmissionColor", Color.black);
            }
        }
        selectedPiece = null;
    }
    // Update is called once per frame
    void Update()
    {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "square" && selectedPiece)
                {
                    selectSquare(hit.transform);
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedPiece.position = hit.transform.position;
                        deselectPiece();
                    }
                 
                }

                if (Input.GetMouseButtonDown(0) && hit.transform.tag == "piece")
                
                {

                    selectPiece(hit.transform);

                }
            }

    }
}
