using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class VisibilityZone : MonoBehaviour
{

    [SerializeField] List<VisibilityZone> neighbourZones = new List<VisibilityZone>();

    List<EnemyVisibilityZone> enemies = new List<EnemyVisibilityZone>();
    HashSet<VisibilityZone> zonesWhereThisIsNeighbour = new HashSet<VisibilityZone>();
    VisibilityZone_DebugParameters debugParameters;
    int playerLayer, enemyLayer;
    int playersInZone = 0;

    public bool HasPlayers { get { return playersInZone > 0; } }
    public bool NeighbourHasPlayers
    {
        get
        {
            foreach(VisibilityZone neighbour in neighbourZones)
            {
                if (neighbour.HasPlayers) return true;
            }
            return false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");

        foreach(VisibilityZone neighbour in neighbourZones)
        {
            neighbour.AddZoneWhereThisIsNeighbour(this);
        }
    }

    public void AddZoneWhereThisIsNeighbour(VisibilityZone _zone)
    {
        if (!zonesWhereThisIsNeighbour.Contains(_zone))
            zonesWhereThisIsNeighbour.Add(_zone);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            PlayerEntersVisibilityZone();
        }

        if (other.gameObject.layer == enemyLayer)
        {
            EnemyEntersVisibilityZone(other.GetComponent<EnemyVisibilityZone>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            PlayerExitsVisibilityZone();
        }

        if (other.gameObject.layer == enemyLayer)
        {
            EnemyExitsVisibilityZone(other.GetComponent<EnemyVisibilityZone>());
        }
    }

    void PlayerEntersVisibilityZone()
    {
        if (!HasPlayers)
        {
            MakeAllEnemiesVisible(true);
            foreach(VisibilityZone neighbour in neighbourZones)
            {
                neighbour.MakeAllEnemiesVisible(true);
            }
        }
        playersInZone++;
        DebugTriggerZoneMessage(true);
    }

    void PlayerExitsVisibilityZone()
    {
        playersInZone--;
        if (!HasPlayers)
        {
            if (!NeighbourHasPlayers) MakeAllEnemiesVisible(false);
            foreach(VisibilityZone neighbour in zonesWhereThisIsNeighbour)
            {
                if (!neighbour.HasPlayers && !neighbour.NeighbourHasPlayers)
                    neighbour.MakeAllEnemiesVisible(false);
            }
        }
        DebugTriggerZoneMessage(false);
    }

    public void MakeAllEnemiesVisible(bool _visible)
    {
        foreach (EnemyVisibilityZone enemy in enemies)
        {
            enemy.MakeVisible(_visible);
        }
    }

    void EnemyEntersVisibilityZone(EnemyVisibilityZone _enemy)
    {
        if(_enemy == null)
        {
            Debug.LogWarning("EnemyVisibilityZone component not found.");
            return;
        }

        enemies.Add(_enemy);
        _enemy.AddToVisibilityZone(this);
    }

    void EnemyExitsVisibilityZone(EnemyVisibilityZone _enemy)
    {
        if (_enemy == null)
        {
            Debug.LogWarning("EnemyVisibilityZone component not found.");
            return;
        }

        enemies.Remove(_enemy);
        _enemy.RemoveVisibilityZone(this);
    }

    public bool RemoveEnemyFromVisibilityZone(EnemyVisibilityZone _enemy)
    {
        return enemies.Remove(_enemy);
    }



    /// Debug Functions
    void DebugTriggerZoneMessage(bool _entersZone)
    {
        if (!debugParameters.triggerZoneMessageEnabled) return;

        if (_entersZone) Debug.Log("VisibilityZone Debug Message: Player has entered " + gameObject.name);
        else Debug.Log("VisibilityZone Debug Message: Player has exit " + gameObject.name);
    } 

    public void SetUpDebugParameters(VisibilityZone_DebugParameters _debugParameters)
    {
        debugParameters = _debugParameters;
        if (Application.isPlaying)
        {
            EnableAuxiliarMesh(debugParameters.auxiliarMeshEnabledInPlayMode);
        }
        else
        {
            EnableAuxiliarMesh(debugParameters.auxiliarMeshEnabledInEditMode);
        }

    }

    void EnableAuxiliarMesh(bool _enable)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogWarning("MeshRenderer component not found.");
            return;
        }

        meshRenderer.enabled = _enable;
    }

}
