// 6.1 Create a seperate class file. Name it Information.cs
class Information : IComparable<Information>  // add an appropriate IComparable for the Name attribute
{
    public Information()
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
    public void MutateData(string nameInfo, string structureInfo, string categoryInfo, string definitionInfo) // Setter
    {
        name = nameInfo;
        structure = structureInfo;
        category = categoryInfo;
        defintion = definitionInfo;
    }

    public Information(string nameSearch) => name = nameSearch;
    public Information(string nameInfo, string structureInfo, string categoryInfo, string definitionInfo)
    {
        name = nameInfo;
        structure = structureInfo;
        category = categoryInfo;
        defintion = definitionInfo;
    }
    public int CompareTo(Information? compareName) // A sort method for the IComparable
    {
        return name.CompareTo(compareName?.name);
    }
}