using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisibilityZone : MonoBehaviour
{
    [SerializeField] GameObject bodyRef;

    List<VisibilityZone> visibilityZones = new List<VisibilityZone>();


    private void Start()
    {
        MakeVisible(false);
    }


    public void AddToVisibilityZone(VisibilityZone _zone)
    {
        if (_zone.HasPlayers && !IsVisible()) MakeVisible(true);
        else if (!_zone.HasPlayers && IsVisible())
        {
            VisibilityZone VisibilityZoneWithPlayer = visibilityZones.Find(zone => zone.HasPlayers);
            MakeVisible(VisibilityZoneWithPlayer != null);
        }

        visibilityZones.Add(_zone);
    }

    public bool RemoveVisibilityZone(VisibilityZone _zone)
    {
        bool successfullyRemoved = visibilityZones.Remove(_zone);
        if (visibilityZones.Count <= 0 && IsVisible()) MakeVisible(false);

        return successfullyRemoved;
    }

    public void RemoveAllVisibilityZones()
    {
        foreach(VisibilityZone zone in visibilityZones)
        {
            zone.RemoveEnemyFromVisibilityZone(this);
        }
    }


    public void MakeVisible(bool _visible)
    {
        if(IsVisible() != _visible) 
            bodyRef.SetActive(_visible);
    }

    public bool IsVisible()
    {
        return bodyRef.activeInHierarchy;
    }

}
