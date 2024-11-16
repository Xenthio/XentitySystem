using Sandbox;
namespace XentitySystem;
public class ModelEntity : Entity
{
	public SceneModel SceneModel { get; private set; }
	public PhysicsBody PhysicsBody { get; private set; }

	public override bool IsValid => SceneModel.IsValid() && PhysicsBody.IsValid();

	public ModelEntity( SceneModel sceneModel )
	{
		SceneModel = sceneModel;
	}

	public void SetModel( Model model )
	{
		if ( SceneModel.IsValid() ) SceneModel.Model = model;
		else
		{
			SceneModel = new SceneModel( Game.ActiveScene.SceneWorld, model, Transform.World );
		}
	}
	public enum SetupPhysicsMode
	{
		Dynamic,
		Static,
		Kinematic
	}
	public void SetupPhysicsFromModel( SetupPhysicsMode mode )
	{
		// Ignore mode for now
		PhysicsBody = new PhysicsBody( Game.ActiveScene.PhysicsWorld );

		foreach ( var part in SceneModel.Model.Physics.Parts )
		{
			foreach ( var hull in part.Hulls ) PhysicsBody.AddShape( hull, PhysicsBody.Transform.ToLocal( Transform.World ).ToWorld( part.Transform ) );
			foreach ( var mesh in part.Meshes ) PhysicsBody.AddShape( mesh, PhysicsBody.Transform.ToLocal( Transform.World ).ToWorld( part.Transform ), false );
		}
	}
	protected override void OnDeleteInternal()
	{
		base.OnDeleteInternal();
		SceneModel?.Delete();
		PhysicsBody?.Remove();
	}
}
