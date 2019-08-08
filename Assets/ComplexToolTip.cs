using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexToolTip : MonoBehaviour, ITooltip
{
    public int minDamage;
    public int maxDamage;
    public string[] effects;

    public string GetTip()
    {
        // trick here is to put  anewline at the start of each new line, so we dont get left with a newline at the end

        string tip = "<b>" + name + "</b>"; // name in bold, no newline yet

        // write out damage intelligently (TODO - write -4 to -6 as "4-6 Heal" etc? )
        if (minDamage == maxDamage)
        {
            if (minDamage !=0)
                tip += "\n" + minDamage + " damage"; // single number for non-zero flat damage
            // note that 0-0 gets nothing!
        }
        else
            tip += "\n" + minDamage + "-" + maxDamage + " damage"; // variable amage string - note no newline at end

        foreach (string s in effects) // newline for each effect comes before
            tip += "\n" + s;

        // note that this way we don't end on a newline

        return tip;
    }
}
