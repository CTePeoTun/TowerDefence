using System;
using UnityEngine;

namespace TowerDefence
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController characterController;
        public float speed;
    }
}