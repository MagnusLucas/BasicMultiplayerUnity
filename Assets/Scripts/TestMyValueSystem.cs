using Unity.Burst;
using Unity.Entities;
using UnityEngine;

partial struct TestMyValueSystem : ISystem
{

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRO<MyValue> myValue,
            Entity entity)
            in SystemAPI.Query<RefRO<MyValue>>().WithEntityAccess()) {
            Debug.Log(myValue.ValueRO.value + "::" + entity + "::" + state.World);
        }
    }

}

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation)]
partial struct TestMyValueServerSystem : ISystem {
    public void OnUpdate(ref SystemState state) {
        foreach ((
            RefRW<MyValue> myValue,
            Entity entity)
            in SystemAPI.Query<RefRW<MyValue>>().WithEntityAccess()) {

                if (Input.GetKey(KeyCode.V)) {
                    myValue.ValueRW.value = UnityEngine.Random.Range(100, 200);
                    Debug.Log(myValue.ValueRW.value + "::" + entity + "::" + state.World);
                }
            }
        }
    }
