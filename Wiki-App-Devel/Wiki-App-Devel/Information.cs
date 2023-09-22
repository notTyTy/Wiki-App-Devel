// 6.1 Create a seperate class file. Name it Information.cs
class Information : IComparable<Information>
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
    public void GetName(string nameInfo) // Setter
    {
        name = nameInfo;
    } 
    public string GetStructure() 
    {
        return structure;
    }
    public void GetStructure(string structureInfo)
    {
        structure = structureInfo;
    }
    public string GetCategory()
    {
        return category;
    }
    public void GetCategory(string categoryInfo)
    {
        category = categoryInfo;
    }
    public string GetDefinition()
    {
        return defintion;
    }
    public void GetDefinition(string definitionInfo)
    {
        defintion = definitionInfo;
    }


    public Information(string nameInfo, string structureInfo, string categoryInfo, string definitionInfo)
    {
        name = nameInfo;
        structure = structureInfo;
        category = categoryInfo;
        defintion = definitionInfo;
    }

    public int CompareTo(Information compareName)
    {
        return this.name.CompareTo(compareName.name);
    }
}