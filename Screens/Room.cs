﻿using System.Text;
using BaboonComputer.Interfaces;
using GorillaNetworking;
using GorillaTagScripts;

namespace BaboonComputer.Screens;

public class Room : IBaboonComputerScreen
{
    public string Name => "Room";

    public string RoomCode
    {
        get => NetworkSystem.Instance.RoomName;
        set => PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(value,
            FriendshipGroupDetection.Instance.IsInParty ? JoinType.ForceJoinWithParty : JoinType.Solo);
    }

    public bool RoomCodeValid => _currentlyInputtedRoomCode.Length > 0 && _currentlyInputtedRoomCode != RoomCode;

    public void Leave()
    {
        if (FriendshipGroupDetection.Instance.IsInParty)
            FriendshipGroupDetection.Instance.LeaveParty();

        NetworkSystem.Instance.ReturnToSinglePlayer();
    }

    public void JoinRandomPublic()
    {
        PhotonNetworkController.Instance.AttemptToJoinPublicRoom(GorillaComputer.instance.GetSelectedMapJoinTrigger(),
            FriendshipGroupDetection.Instance.IsInParty ? JoinType.ForceJoinWithParty : JoinType.Solo);
    }

    private string _currentlyInputtedRoomCode = "";

    // not to be confused with Update()
    public void UpdateScreenText()
    {
        var screenBuilder = new StringBuilder();

        screenBuilder.AppendLine("Input a room code and press Enter to join that room. Press Option 1 to leave the current room. Press Option 2 to join a new public room.");
        screenBuilder.AppendLine($"Code: {_currentlyInputtedRoomCode}");

        SetText(screenBuilder.ToString());
    }

    public void OnKeyPressed(ComputerKey key)
    {
        switch (key)
        {
            case ComputerKey.Backspace:
                if (_currentlyInputtedRoomCode.Length > 0)
                    _currentlyInputtedRoomCode = _currentlyInputtedRoomCode[..^2];

                break;
            case ComputerKey.Enter:
                if (RoomCodeValid)
                    RoomCode = _currentlyInputtedRoomCode;

                break;
            case ComputerKey.Opt1:
                if (NetworkSystem.Instance.InRoom)
                    Leave();

                break;
            case ComputerKey.Opt2:
                JoinRandomPublic();
                break;
            case ComputerKey.Opt3:
                break;
            default:
                _currentlyInputtedRoomCode += key.ToRealKeyName();
                break;
        }

        UpdateScreenText();
    }
}