using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class SelectedPost : ScriptableObject
{
    private PostComponent _value = null;
    public SelectedPostChangedEvent OnValueChanged;
    public PostComponent Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged.Invoke(_value);
            }
        }
    }
}
[System.Serializable]
public class SelectedPostChangedEvent : UnityEvent <PostComponent> { }
