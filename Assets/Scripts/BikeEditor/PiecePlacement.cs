using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacement : MonoBehaviour {

    public Piece piece;
    public LayerMask targetLayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            hit = GetCursorTargetHit(Input.mousePosition, targetLayer);
            if (hit.collider)
            {
                SnapToSurface(piece.transform, hit.point, hit.normal, piece.junctionPoint.localPosition);
            }
            
        }
	}

    RaycastHit GetCursorTargetHit (Vector3 cursorPosition, LayerMask layerMask)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(cursorPosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);

        return hit;
  
    }

    void SnapToSurface (Transform obj, Vector3 destination, Vector3 normal, Vector3 offset)
    {
        obj.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        piece.transform.position = destination - obj.TransformDirection(offset);
    }

}
