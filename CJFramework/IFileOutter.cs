using CJPlus.FileTransceiver;
using System;

internal interface IFileOutter
{
    event CbFileTransCompleted FileTransCompleted;

    event CbFileTransDisruptted FileTransDisruptted;

    event CbFileSendedProgress FileTransProgress;

    void HnFdepcbbe(bool bool_0);
    void imethod_0(FileTransDisrupttedType fileTransDisrupttedType_0, string string_0);
    FileTransferingProgress imethod_1();
    int imethod_10();
    void imethod_11(int int_0);
    int imethod_12();
    void imethod_13(int int_0);
    void imethod_2();
    bool imethod_3();
    string imethod_4();
    string imethod_5();
    void imethod_6(string string_0);
    ulong imethod_7();
    int imethod_8();
    void imethod_9(int int_0);
}

