using CJBasic.ObjectManagement.Managers;
using CJPlus.Application;
using System;

internal class Class76
{
    private SafeDictionary<string, Contract> safeDictionary_0 = new SafeDictionary<string, Contract>();

    private string Format(string string_0, int int_0)
    {
        return string.Format("{0}#{1}", string_0, int_0);
    }

    public Information method_1(string string_0, string string_1, BlobFragmentContract blobFragmentContract_0)
    {
        if ((blobFragmentContract_0.BlobID == 1) && (blobFragmentContract_0.FragmentIndex == 0))
        {
            this.OnUserOffline(string_0);
        }
        if ((blobFragmentContract_0.FragmentIndex == 0) && blobFragmentContract_0.IsLast)
        {
            return new Information(string_0, string_1, blobFragmentContract_0.InformationType, blobFragmentContract_0.Fragment);
        }
        string id = this.Format(string_0, blobFragmentContract_0.BlobID);
        Contract class2 = this.safeDictionary_0.Get(id);
        if (class2 == null)
        {
            class2 = new Contract(blobFragmentContract_0.BlobID, string_0, string_1, blobFragmentContract_0.InformationType);
            this.safeDictionary_0.Add(id, class2);
        }
        Information information = class2.GetInformation(blobFragmentContract_0);
        if (information != null)
        {
            this.safeDictionary_0.Remove(id);
        }
        return information;
    }

    public void OnUserOffline(string string_0)
    {
        //<>c__DisplayClass1 class2;
        //string userID = string_0;
        //this.safeDictionary_0.RemoveByPredication(new Predicate<Contract>(class2.<OnUserOffline>b__0));
    }

    public void Clear()
    {
        this.safeDictionary_0.Clear();
    }
}

