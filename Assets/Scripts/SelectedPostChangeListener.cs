using UnityEngine;

public class SelectedPostChangeListener : MonoBehaviour
{
    public SelectedPost selectedPostAsset = null;

    private void Start()
    {
        if (selectedPostAsset != null)
        {
            selectedPostAsset.OnValueChanged.AddListener(OnValueChangeNotified);
            gameObject.transform.position = selectedPostAsset.Value.markerPosition.position;
        }
        else Debug.Log($"{name}.Start: selectedPostAsset is null.");
    }
    public void OnValueChangeNotified(PostComponent newPost)
    {
        gameObject.transform.position = newPost.markerPosition.position;
    }
}
