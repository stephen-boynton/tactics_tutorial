using System.Collections;
using UnityEngine;
public class BattleController : StateMachine {
  public CameraRig cameraRig;
  public Board board;
  public LevelData levelData;
  public Transform tileSelectionIndicator;
  public GameObject heroPrefab;
  public Unit currentUnit;
  public Tile currentTile { get { return board.GetTile (pos); } }
  public Point pos;
  void Start () {
    ChangeState<InitBattleState> ();
  }
}