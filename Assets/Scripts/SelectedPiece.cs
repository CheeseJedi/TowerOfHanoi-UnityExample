using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class SelectedPiece : ScriptableObject
{
    private PieceComponent _value = default;
    //public SelectedPieceChangedEvent OnValueChanged;
    public PieceComponent Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                //OnValueChanged.Invoke(_value);
            }
        }
    }
}
//[System.Serializable]
//public class SelectedPieceChangedEvent : UnityEvent<PieceComponent> { }
