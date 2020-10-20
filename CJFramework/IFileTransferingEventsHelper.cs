using CJBasic;
using CJPlus.FileTransceiver;
using System;
using System.Collections.Generic;

internal interface IFileTransferingEventsHelper : IFileTransferingEvents, IDisposable
{
    event CbGeneric<string> SingleFileRevFinished;

    ResumedProjectItem imethod_0(TransferingProject transferingProject_0);
    void imethod_1(TransferingProject transferingProject_0);
    TransferingProject GetTransferingProject(string string_0);
    FileTransferingProgress GetFileTransferingProgress(string string_0);
    List<string> GetFileTransHelper(string string_0);
    void imethod_13();
    void imethod_2(string string_0);
    TransferingProject imethod_3(string string_0);
    void imethod_4(TransferingProject transferingProject_0, ResumedProjectItem resumedProjectItem_0, bool bool_0);
    void imethod_5(string string_0, FileTransDisrupttedType fileTransDisrupttedType_0, string string_1);
    void imethod_6();
    void imethod_7(string string_0);
    void imethod_8(string string_0);
    string imethod_9(string string_0);
    void ocqOcyhOmB(string string_0, FilePackage filePackage_0);

    int TTL4ResumedFileItem { get; set; }
}

