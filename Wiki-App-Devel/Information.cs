// 6.1 Create a seperate class file. Name it Information.cs
class Information : IComparable<Information>  // add an appropriate IComparable for the Name attribute
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Information()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    { }
    // 6.1 Use privte properties for the fields which must be type string
    private string name;
    private string structure;
    private string category;
    private string defintion;

    public string GetName() // Getter
    {
        return name;
    }
    public string GetStructure()
    {
        return structure;
    }
    public string GetCategory()
    {
        return category;
    }
    public string GetDefinition()
    {
        return defintion;
    }
    public void SetName(string nameInfo)
    {
        name = nameInfo;
    }
    public void SetStructure(string structureInfo)
    {
        structure = structureInfo;
    }
    public void SetCategory(string categoryInfo)
    {
        category = categoryInfo;
    }
    public void SetDefinition(string definitionInfo)
    {
        defintion = definitionInfo;
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Information(string nameSearch)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        name = nameSearch;
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Information(string nameInfo, string structureInfo, string categoryInfo, string definitionInfo)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        SetName(nameInfo);
        SetStructure(structureInfo);
        SetCategory(categoryInfo);
        SetDefinition(definitionInfo);
    }
    public int CompareTo(Information? compareName) // A sort method for the IComparable
    {
        return name.CompareTo(compareName?.name);
    }
}