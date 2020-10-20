using CJBasic.Emit.ForEntity;
using System;
using System.Reflection;

internal sealed class Class137
{
    private IPropertyQuicker ipropertyQuicker_0;
    private PropertyInfo[] propertyInfo_0;

    public Class137()
    {
    }

    public Class137(IPropertyQuicker ipropertyQuicker_1, PropertyInfo[] propertyInfo_1)
    {
        this.ipropertyQuicker_0 = ipropertyQuicker_1;
        this.propertyInfo_0 = propertyInfo_1;
    }

    public void EsfclJixyM(IPropertyQuicker ipropertyQuicker_1)
    {
        this.ipropertyQuicker_0 = ipropertyQuicker_1;
    }

    public IPropertyQuicker method_0()
    {
        return this.ipropertyQuicker_0;
    }

    public PropertyInfo[] method_1()
    {
        return this.propertyInfo_0;
    }

    public void method_2(PropertyInfo[] propertyInfo_1)
    {
        this.propertyInfo_0 = propertyInfo_1;
    }
}

