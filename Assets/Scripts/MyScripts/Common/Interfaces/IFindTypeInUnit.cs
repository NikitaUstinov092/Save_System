public interface IFindTypeInUnit<Type>
{
    Type[] GetTypeData();
    Type GetTypeById(int id);
    int GetidByType(Type unitObject);
}
