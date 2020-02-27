using System.Collections;
using UnityEngine;

public class DefaultAbilityEffectTarget : AbilityEffectTarget {
    public override bool IsTarget (Tile tile) {
        if (tile == null || tile.content == null){
            Debug.Log("This is definitely the problem");
            return false;

        }

        Stats s = tile.content.GetComponent<Stats> ();
        Debug.Log(s);
        return s != null && s[StatTypes.HP] > 0;
    }
}