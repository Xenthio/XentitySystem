using Sandbox;

namespace XentitySystem;

internal class EntityDummyComponent : Component
{
	private Entity OwnerEntity;
	protected override void OnStart()
	{
		base.OnStart();
		OwnerEntity = GameObject as Entity;
		OwnerEntity.Name = GameObject.GetType().Name;
	}
	protected override void OnUpdate()
	{
		base.OnUpdate();
		OwnerEntity.InternalUpdate();
	}
	protected override void OnFixedUpdate()
	{
		base.OnFixedUpdate();
		OwnerEntity.InternalFixedUpdate();
	}
}
