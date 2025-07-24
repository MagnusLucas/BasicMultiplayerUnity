using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

[UpdateInGroup(typeof(GhostInputSystemGroup))]
partial struct NetcodePlayerInputSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<NetworkStreamInGame>();
        state.RequireForUpdate<NetcodePlayerInput>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ((
            RefRW<NetcodePlayerInput> netcodePlayerInput, 
            RefRW<MyValue> myValue) 
            in SystemAPI.Query<RefRW<NetcodePlayerInput>, RefRW<MyValue>>().WithAll<GhostOwnerIsLocal>()){

            float2 inputVector = new float2();

            if (Input.GetKey(KeyCode.W)) {
                inputVector.y += 1f;
            }
            if (Input.GetKey(KeyCode.S)) {
                inputVector.y -= 1f;
            }
            if (Input.GetKey(KeyCode.D)) {
                inputVector.x -= 1f;
            }
            if (Input.GetKey(KeyCode.A)) {
                inputVector.x += 1f;
            }


            if (Input.GetKey(KeyCode.V)) {
                myValue.ValueRW.value = UnityEngine.Random.Range(100, 200);
                Debug.Log("New player value: " +  myValue.ValueRW.value);
            }

            netcodePlayerInput.ValueRW.inputVector = inputVector;
        }
        
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
