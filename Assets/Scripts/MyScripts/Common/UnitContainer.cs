using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitContainer: MonoBehaviour
{
    public List<GameObject> GetAllUnitsObjects => _allUnits.Where(obj => obj != null).ToList();
    public GameObject SetUnitToList
    {
        set
        {
            _allUnits.RemoveAll(empty => empty == null);
            _allUnits.Add(value);
        }
    }
    public GameObject[] GetAllUnitsTypes => _unitsTypes.Units;

    [Tooltip("���������� ��� ����������� GameObjects")]
    [SerializeField] private List<GameObject> _allUnits;

    [Tooltip("���������� ���� ������")]
    [SerializeField] private UnitsTypeContainer _unitsTypes;   
}
