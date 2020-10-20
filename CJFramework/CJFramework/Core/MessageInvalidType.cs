namespace CJFramework.Core
{
    using System;

    public enum MessageInvalidType
    {
        Valid,
        MessageSizeOverflow,
        InvalidHeader,
        InvalidToken,
        DataLacked,
        InvalidClientType
    }
}

