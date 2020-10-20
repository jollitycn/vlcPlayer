using CJBasic;
using CJPlus.FileTransceiver;
using System;

internal interface IFileTransHelper
{
    event CbGeneric<string> FileTransCompleted;

    event CbFileTransDisruptted FileTransDisruptted;

    event CbFileSendedProgress FileTransProgress;

    void FileReceive(FilePackage filePackage_0);
    void imethod_1(FileTransDisrupttedType fileTransDisrupttedType_0, bool bool_0, string string_0);
    FileTransferingProgress imethod_2();
    void imethod_3();
    bool imethod_4();
    string imethod_5();
    ulong imethod_6();
    string imethod_7();
    string imethod_8();
    ulong imethod_9();
}

