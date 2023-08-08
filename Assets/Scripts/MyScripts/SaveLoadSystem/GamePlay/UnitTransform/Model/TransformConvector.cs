using UnityEngine;

public struct TransformConvector
{ 
    public UnitTransform ConvertTransformTo(Transform transform, int unitId)
    {
        var resault = new UnitTransform();

        resault.PosX = transform.localPosition.x;
        resault.PosY = transform.localPosition.y;
        resault.PosZ = transform.localPosition.z;

        resault.RosX = transform.localRotation.eulerAngles.x; 
        resault.RosY = transform.localRotation.eulerAngles.y; 
        resault.RosZ = transform.localRotation.eulerAngles.z; 

        resault.ScaleX = transform.localScale.x;
        resault.ScaleY = transform.localScale.y;
        resault.ScaleZ = transform.localScale.z;

        resault.UserId = unitId;

        return resault;
    }

    public Transform ConvertTransformFrom(UnitTransform savedTransform, Transform current)
    {
        current.localPosition = new Vector3(savedTransform.PosX, savedTransform.PosY, savedTransform.PosZ);
        current.localRotation = Quaternion.Euler(savedTransform.RosX, savedTransform.RosY, savedTransform.RosZ); 
        current.localScale = new Vector3(savedTransform.ScaleX, savedTransform.ScaleY, savedTransform.ScaleZ);
        return current;
    }


}
