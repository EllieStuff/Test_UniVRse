using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisibilityZone_DebugParameters
{
    public bool playerTriggersZoneMessage = false;
    public bool auxiliaryMeshEnabledInEditMode = false;
    public bool auxiliaryMeshEnabledInPlayMode = false;

    public VisibilityZone_DebugParameters() { }
    public VisibilityZone_DebugParameters(VisibilityZone_DebugParameters _debugParameters)
    {
        playerTriggersZoneMessage = _debugParameters.playerTriggersZoneMessage;
        auxiliaryMeshEnabledInEditMode = _debugParameters.auxiliaryMeshEnabledInEditMode;
        auxiliaryMeshEnabledInPlayMode = _debugParameters.auxiliaryMeshEnabledInPlayMode;
    }
    public VisibilityZone_DebugParameters(bool _playerTriggersZoneMessage, bool _auxiliaryMeshEnabledInEditMode, bool _auxiliaryMeshEnabledInPlayMode)
    {
        playerTriggersZoneMessage = _playerTriggersZoneMessage;
        auxiliaryMeshEnabledInEditMode = _auxiliaryMeshEnabledInEditMode;
        auxiliaryMeshEnabledInPlayMode = _auxiliaryMeshEnabledInPlayMode;
    }

}
