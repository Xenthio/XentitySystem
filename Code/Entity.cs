using Sandbox;
using System.Collections.Generic;
namespace XentitySystem;
public class Entity : GameObject
{
	public static List<Entity> All = new List<Entity>();
	internal Component DummyComponent;

	public Entity()
	{
		All.Add( this );
		DummyComponent = Components.GetOrCreate<EntityDummyComponent>();
		Spawn();
	}
	public virtual void InternalUpdate()
	{
	}
	public virtual void InternalFixedUpdate()
	{
	}

	public virtual void Spawn()
	{

	}
	public override void Destroy()
	{
		base.Destroy();
		All.Remove( this );
		OnDestroy();
		OnDestroyInternal();
	}
	protected virtual void OnDestroyInternal()
	{

	}
	protected virtual void OnDestroy()
	{
	}
}
