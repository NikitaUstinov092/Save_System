using UnityEngine;

public class UnitType : MonoBehaviour
{
    public int GetUnitType { get => _unitTypeIndex; }
    public int SetUnitType { set => _unitTypeIndex = value; }

    [Tooltip("C���������� ������� ������� ������� UnitTypeConteiner.GoTypes")]
    [SerializeField] private int _unitTypeIndex; 
  
}
