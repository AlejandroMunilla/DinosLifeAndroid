using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Collectable
{
    int Value { get; set; }
    void Collect();
}
