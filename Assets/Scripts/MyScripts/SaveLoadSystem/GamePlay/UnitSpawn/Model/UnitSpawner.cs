using UnityEngine;
using Zenject;

public class UnitSpawner : MonoBehaviour
{
    [Inject] private UnitContainer _unitСontainer;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private Transform _unitsResourcesParent;
    public void SpawnUnits(int prefabindex, int id)
    {
        var unit = Instantiate(_unitСontainer.GetAllUnitsTypes[prefabindex]);
        AddLoadedDataToInstance(unit, prefabindex, id);
        SortUnits(unit);
    }
    private void SortUnits(GameObject unit)
    {
        if (unit.TryGetComponent(out ResourceObject resource))
            resource.transform.parent = _unitsResourcesParent;
        else
            unit.transform.parent = _unitsParent;
    }
    private void AddLoadedDataToInstance(GameObject instance, int prefabindex, int id)
    {
        if (instance.TryGetComponent(out UnitId unitIdComp))
        {
            unitIdComp.Id = id;
        }
        else
            Debug.LogError("Не найден компонент UnitId на прифабе: " + instance.name);

        if (instance.TryGetComponent(out UnitType unittypeComp))
        {
            unittypeComp.SetUnitType = prefabindex;
        }
        else
            Debug.LogError("Не найден компонент UnitType на прифабе: " + instance.name);

        _unitСontainer.SetUnitToList = instance;
    }
   
    public void CheckParentNull()
    {
        if (_unitsParent == null)
        {
            var newParent = new GameObject("[UNITS]");
            _unitsParent = newParent.transform;
        }
        if (_unitsResourcesParent == null)
        {
            var newParent = new GameObject("[RESOURCES]");
            _unitsResourcesParent = newParent.transform;
        }
    }


    public void RamoveUnit(GameObject unit)
    {
        Destroy(unit);
    }

}
