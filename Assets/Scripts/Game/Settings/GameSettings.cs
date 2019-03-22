using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game.Settings
{
    [Game, Unique, CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject ShotPrefab;
        public float PlayerMoveSpeed = 5f; // meters per second
        public float PlayerRotationSpeed = 180f; //degrees per second		
    }
}