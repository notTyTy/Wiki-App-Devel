using System;
using System.ComponentModel;
// 6.1 Create a seperate class file. Name it Information.cs
class Information : IComparable<Information>
{
    // 6.1 Use privte properties for the fields which must be type string
    private string name;
    private string structure;
    private string category;
    private string defintion;

    public string GetName()
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
    public Information(string nameInfo, string structureInfo, string categoryInfo, string definitionInfo)
    {
        name = nameInfo;
        structure = structureInfo;
        category = categoryInfo;
        defintion = definitionInfo;
    }
    public int SortByNameAscending(string firstVal, string secondVal)
    {
        return firstVal.CompareTo(secondVal);
    }
    public int CompareTo(Information compareName)
    {
        // A null value means that this object is greater.
        if (compareName == null)
        {
            return 1;
        }
        else
        {
            return this.name.CompareTo(compareName.name);
        }
    }
}
