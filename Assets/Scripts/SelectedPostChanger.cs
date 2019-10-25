using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPostChanger : MonoBehaviour
{
    public SelectedPost selectedPostAsset = default;
    public KeyCode previousPostKey = KeyCode.LeftArrow;
    public KeyCode nextPostKey = KeyCode.RightArrow;
    public List<PostComponent> posts = new List<PostComponent>();

    private void Start()
    {
        if (posts.Count > 1)
        {
            selectedPostAsset.Value = posts[1];
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(previousPostKey))
        {
            selectedPostAsset.Value = posts.GetNextInCycle(selectedPostAsset.Value, reverse: true);
        }
        if (Input.GetKeyDown(nextPostKey))
        {
            selectedPostAsset.Value = posts.GetNextInCycle(selectedPostAsset.Value, reverse: false);
        }
    }
}
