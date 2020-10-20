using System;

internal interface IBody
{
    void ToStream(byte[] stream, int startIndex);

    int BodyTotalLength { get; }
}

