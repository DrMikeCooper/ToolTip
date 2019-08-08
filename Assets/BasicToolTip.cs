using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicToolTip : MonoBehaviour, ITooltip
{
    [Multiline]
    public string tip;

    public string GetTip()
    {
        return tip;
    }
}
