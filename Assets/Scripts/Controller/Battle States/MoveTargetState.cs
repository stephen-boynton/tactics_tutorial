using System.Collections;
using UnityEngine;
public class MoveTargetState : BattleState {
  protected override void OnMove (object sender, InfoEventArgs<Point> e) {
    SelectTile (e.info + pos);
  }
}