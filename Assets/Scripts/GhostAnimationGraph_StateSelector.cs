using System.Collections.Generic;
using Unity.NetCode;
using Unity.NetCode.Hybrid;
using UnityEngine;
using UnityEngine.Playables;



public class GhostAnimationGraph_StateSelector : GhostAnimationGraphAsset {

    public override Playable CreatePlayable(GhostAnimationController controller, PlayableGraph graph, List<GhostPlayableBehaviour> behaviours) {
        return ScriptPlayable<StateSelectorGhostPlayableBehaviour>.Create(graph);
    }

    public override void RegisterPlayableData(IRegisterPlayableData register) {
    }
}

public class StateSelectorGhostPlayableBehaviour : GhostPlayableBehaviour {
    public override void PreparePredictedData(NetworkTick serverTick, float deltaTime, bool isRollback) {
    }

}