using System.Collections.Generic;
using Unity.NetCode.Hybrid;
using UnityEngine;
using UnityEngine.Playables;

public class GhostAnimationGraph_Idle : GhostAnimationGraphAsset {

    public override Playable CreatePlayable(GhostAnimationController controller, PlayableGraph graph, List<GhostPlayableBehaviour> behaviours) {
        return ScriptPlayable<StateSelectorGhostPlayableBehaviour>.Create(graph);
    }

    public override void RegisterPlayableData(IRegisterPlayableData register) {
    }
}
