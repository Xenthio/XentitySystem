using Sandbox;
using System;
using System.Collections.Generic;
namespace XentitySystem;
public class Entity : IValid, IDisposable
{
	public static List<Entity> All = new List<Entity>();
	public virtual bool IsValid => true;
	public GameTransform Transform { get; set; }

	public Entity()
	{
		All.Add( this );
	}
	public void Dispose()
	{
		All.Remove( this );
		OnDelete();
		OnDeleteInternal();
	}
	public void Delete()
	{
		Dispose();
	}
	protected virtual void OnDeleteInternal()
	{

	}
	protected virtual void OnDelete()
	{
	}
}
