using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AreaLimits
{
    public float minX, maxX, minY, maxY, minZ, maxZ;

    public AreaLimits(BoxCollider _spawnArea)
    {
        float spawnAreaXMargin = _spawnArea.size.x / 2f;
        minX = _spawnArea.center.x - spawnAreaXMargin;
        maxX = _spawnArea.center.x + spawnAreaXMargin;

        float spawnAreaYMargin = _spawnArea.size.y / 2f;
        minY = _spawnArea.center.y - spawnAreaYMargin;
        maxY = _spawnArea.center.y + spawnAreaYMargin;

        float spawnAreaZMargin = _spawnArea.size.z / 2f;
        minZ = _spawnArea.center.z - spawnAreaZMargin;
        maxZ = _spawnArea.center.z + spawnAreaZMargin;
    }

}
