using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisibilityZones_DebugManager : MonoBehaviour
{
    [SerializeField] VisibilityZone_DebugParameters debugParameters;

    // Start is called before the first frame update
    void Awake()
    {
        SetUpChildsDebugParameters();
    }


    void SetUpChildsDebugParameters()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            VisibilityZone childZone = transform.GetChild(i).GetComponent<VisibilityZone>();
            if (childZone == null)
            {
                Debug.LogWarning("VisibilityZone component not found.");
                continue;
            }

            childZone.SetUpDebugParameters(debugParameters);
        }
    }


    [ContextMenu("RefreshDebugParameters")]
    public void RefresheDebugParameters()
    {
        SetUpChildsDebugParameters();
    }

}
