using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Transform selectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void selectPiece(Transform piece)
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "square")
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                    if (selectedPiece)
                    {
                        selectedPiece.position = hit.transform.position;
                        deselectPiece();
                        //selectedPiece.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                    }
                }

                if (hit.transform.tag == "piece")
                {

                    selectPiece(hit.transform);

                }
            }

        }
    }
}
