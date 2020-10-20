using CJFramework.Core;
using CJFramework.Engine.Udp.Reliable;
using CJPlus.Application.P2PSession.Passive;
using CJPlus.FileTransceiver;
using System;

internal class Class56 : Interface2
{
    private IP2PController ip2PController_0;

    public Class56(IP2PController ip2PController_1)
    {
        this.ip2PController_0 = ip2PController_1;
    }

    public SendingFileParas imethod_0(string string_0)
    {
        try
        {
            P2PChannelState state = this.ip2PController_0.GetP2PChannelState(string_0);
            if (state == null)
            {
                return new SendingFileParas(0x800, 0);
            }
            if (state.ProtocolType == ProtocolType.UDP)
            {
                OutUdpSessionState outUdpSessionState = this.ip2PController_0.GetUdpSessionStateViewer().GetOutUdpSessionState(state.DestIPE.IPEndPoint_0);
                if (outUdpSessionState != null)
                {
                    return new SendingFileParas(outUdpSessionState.PMTU - 150, 0);
                }
            }
            if (state.Boolean_0 && (state.ProtocolType == ProtocolType.TCP))
            {
                return new SendingFileParas(0x5000, 0);
            }
            return new SendingFileParas(0x800, 0);
        }
        catch (Exception)
        {
            return new SendingFileParas(0x800, 0);
        }
    }
}

