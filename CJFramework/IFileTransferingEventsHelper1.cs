using CJPlus.FileTransceiver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

internal interface IFileTransferingEventsHelper1 : IFileTransferingEvents
{
    void HnFdepcbbe(string string_0, ulong ulong_0, string string_1, ulong ulong_1);
    int imethod_0();
    void imethod_1(int int_0);
    void imethod_10(string string_0);
    void imethod_11(string string_0);
    void imethod_12(string string_0);
    void imethod_13();
    TransferingProject imethod_2(string string_0);
    FileTransferingProgress imethod_3(string string_0);
    List<string> imethod_4(string string_0);
    void imethod_5(string string_0, string string_1, bool bool_0, ulong ulong_0, DateTime dateTime_0, string string_2, SendingFileParas sendingFileParas_0, string string_3);
    void imethod_6(string string_0, Stream stream_0, string string_1, ulong ulong_0, string string_2, SendingFileParas sendingFileParas_0, string string_3);
    void imethod_7(string string_0, FileTransDisrupttedType fileTransDisrupttedType_0, string string_1);
    void imethod_8(string string_0, out int int_0, out int int_1);
    void imethod_9();
    void Initialize(string string_0, int int_0);
}

