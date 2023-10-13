// 6.1 Create a seperate class file. Name it Information.cs
class Information : IComparable<Information>  // add an appropriate IComparable for the Name attribute
{
    // 6.1 Use privte properties for the fields which must be type string
    private string name;
    private string structure;
    private string category;
    private string defintion;

    public Information() { }

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
    public void SetName(string nameInfo) // Setter
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
    public int CompareTo(Information? compareName) // A sort method for the IComparable
    {
        return name.CompareTo(compareName?.name);
    }
}