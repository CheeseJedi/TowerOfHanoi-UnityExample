using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostComponent : MonoBehaviour
{
    public Transform dropPosition = default;
    public Transform markerPosition = default;
    public SelectedPost selectedPostAsset = default;
    public SelectedPiece selectedPieceAsset = default;
    public Stack<PieceComponent> postStack = new Stack<PieceComponent>();
    public KeyCode pickUpDropKey = KeyCode.Space;
    private void Update()
    {
        if ((selectedPostAsset.Value == this) && Input.GetKeyDown(pickUpDropKey))
        {
            PostInteracted();
        }
    }
    public void PostInteracted()
    {
        if (selectedPieceAsset.Value == null)
        {
            // Pick up piece
            if (!(postStack.Count > 0))
            {
                Debug.Log($"{name}.PostClicked: no pieces to pick up!");
                return;
            }
            PieceComponent piece = postStack.Pop();
            piece.rigidbody.isKinematic = true;
            piece.transform.position = dropPosition.position;
            selectedPieceAsset.Value = piece;
        }
        else
        {
            // Drop piece
            PieceComponent piece = selectedPieceAsset.Value;
            piece.transform.position = dropPosition.position;
            piece.rigidbody.isKinematic = false;
            selectedPieceAsset.Value = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PieceComponent piece = other.gameObject.GetComponent<PieceComponent>();
        if (piece != null)
        {
            postStack.Push(piece);
        }
    }
}
