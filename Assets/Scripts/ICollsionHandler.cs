using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollsionHandler 
{
    void CollisionEnter(string colliderName, GameObject other);
    void CollisionExit(string colliderName, GameObject other);
}
