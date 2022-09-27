using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class Player : MonoBehaviour
{
    private Entity _entity;

    private void OnEnable()
    {
        _entity = GetComponent<Entity>();
    }
}
