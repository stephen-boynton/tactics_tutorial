using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmAbilityTargetState : BattleState {
	List<Tile> tiles;
	AbilityArea aa;
	int index = 0;

	public override void Enter () {
		base.Enter ();
		aa = turn.ability.GetComponent<AbilityArea> ();
		tiles = aa.GetTilesInArea (board, pos);
		board.SelectTiles (tiles);
		FindTargets ();
		RefreshPrimaryStatPanel (turn.actor.tile.pos);
		SetTarget (0);
	}

	public override void Exit () {
		base.Exit ();
		board.DeSelectTiles (tiles);
		statPanelController.HidePrimary ();
		statPanelController.HideSecondary ();
	}

	protected override void OnMove (object sender, InfoEventArgs<Point> e) {
		if (e.info.y > 0 || e.info.x > 0)
			SetTarget (index + 1);
		else
			SetTarget (index - 1);
	}

	protected override void OnFire (object sender, InfoEventArgs<int> e) {
		Debug.Log("On fire called");
		if (e.info == 0) {
			Debug.Log("E.info i === 0");
			Debug.Log(turn.targets.Count);
			if (turn.targets.Count > 0) {
				Debug.Log("I am attacking");
				owner.ChangeState<PerformAbilityState> ();
			}
		} else
			Debug.Log("What the fuck is going on?");
			owner.ChangeState<AbilityTargetState> ();
	}

	void FindTargets () {
		Debug.Log("I'm finding some fucking targets.");
		turn.targets = new List<Tile> ();
		AbilityEffectTarget[] targeters = turn.ability.GetComponentsInChildren<AbilityEffectTarget> ();
		for (int i = 0; i < tiles.Count; ++i)
			if (IsTarget (tiles[i], targeters))
				turn.targets.Add (tiles[i]);
	}

	bool IsTarget (Tile tile, AbilityEffectTarget[] list) {
		for (int i = 0; i < list.Length; ++i)
			if (list[i].IsTarget (tile))
				return true;

		return false;
	}

	void SetTarget (int target) {
		index = target;
		if (index < 0)
			index = turn.targets.Count - 1;
		if (index >= turn.targets.Count)
			index = 0;
		if (turn.targets.Count > 0)
			RefreshSecondaryStatPanel (turn.targets[index].pos);
	}
}