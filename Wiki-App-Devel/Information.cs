using System;
using System.ComponentModel;
// 6.1 Create a seperate class file. Name it Information.cs
class Information
{
    // 6.1 Use privte properties for the fields which must be type string
    private string name;
    private string structure;
    private string category;
    private string defintion;

    public string GetName(string nameInfo)
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
    public Information(string nameInfo, string categoryInfo, string structureInfo, string definitionInfo)
    {
        name = nameInfo;
        category = categoryInfo;
        structure = structureInfo;
        defintion = definitionInfo;
    }
}
