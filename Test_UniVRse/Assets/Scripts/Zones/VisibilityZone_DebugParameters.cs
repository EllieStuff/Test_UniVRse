using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisibilityZone_DebugParameters
{
    public bool triggerZoneMessageEnabled = false;
    public bool auxiliarMeshEnabledInEditMode = false;
    public bool auxiliarMeshEnabledInPlayMode = false;

    public VisibilityZone_DebugParameters() { }
    public VisibilityZone_DebugParameters(VisibilityZone_DebugParameters _debugParameters)
    {
        triggerZoneMessageEnabled = _debugParameters.triggerZoneMessageEnabled;
        auxiliarMeshEnabledInEditMode = _debugParameters.auxiliarMeshEnabledInEditMode;
        auxiliarMeshEnabledInPlayMode = _debugParameters.auxiliarMeshEnabledInPlayMode;
    }
    public VisibilityZone_DebugParameters(bool _triggerZoneWarningEnabledInPlayMode, bool _auxiliarMeshEnabledInEditMode, bool _auxiliarMeshEnabledInPlayMode)
    {
        triggerZoneMessageEnabled = _triggerZoneWarningEnabledInPlayMode;
        auxiliarMeshEnabledInEditMode = _auxiliarMeshEnabledInEditMode;
        auxiliarMeshEnabledInPlayMode = _auxiliarMeshEnabledInPlayMode;
    }

}
