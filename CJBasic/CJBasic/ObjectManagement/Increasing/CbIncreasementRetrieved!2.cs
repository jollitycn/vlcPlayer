namespace CJBasic.ObjectManagement.Increasing
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public delegate void CbIncreasementRetrieved<TRoundID, TObject>(List<TObject> list, TRoundID currentRoundID, bool isLastPhaseOfRound);
}

