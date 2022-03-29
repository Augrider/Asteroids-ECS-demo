using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaveProvider
{
    IEntitySpawnProvider[] GetEntitiesToSpawn(int waveCount);
}