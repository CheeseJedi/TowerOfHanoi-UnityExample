using UnityEngine;

[RequireComponent(typeof(Renderer)), RequireComponent(typeof(Rigidbody))]
public class PieceComponent : MonoBehaviour
{
    public Color color = Color.white;
    public float size = 1f;
    public new Rigidbody rigidbody;
    public SelectedPiece selectedPieceAsset = default;
    public SelectedPost selectedPostAsset = null;
    private void Start()
    {
        GetComponent<Renderer>().material.color = color;
        //rigidbody.mass *= size;
        transform.localScale = new Vector3
            (transform.localScale.x * size, transform.localScale.y, transform.localScale.z * size);

        if (selectedPostAsset != null)
        {
            selectedPostAsset.OnValueChanged.AddListener(OnValueChangeNotified);
            //gameObject.transform.position = selectedPostAsset.Value.dropPosition.position;
        }
        else Debug.Log($"{name}.Start: selectedPostAsset is null.");
    }
    public void OnValueChangeNotified(PostComponent newPost)
    {
        if (selectedPieceAsset == this)
            gameObject.transform.position = newPost.dropPosition.position;
    }
}
