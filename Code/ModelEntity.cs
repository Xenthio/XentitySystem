using Sandbox;
namespace XentitySystem;
public class ModelEntity : Entity
{
	public SkinnedModelRenderer ModelRenderer { get; private set; }
	public Rigidbody Rigidbody { get; private set; }

	public void SetModel( Model model )
	{
		ModelRenderer = Components.GetOrCreate<SkinnedModelRenderer>();
		ModelRenderer.Model = model;
	}
	public enum SetupPhysicsMode
	{
		Dynamic,
		Static,
		Kinematic
	}
	public void SetupPhysicsFromModel( SetupPhysicsMode mode )
	{
		if ( ModelRenderer.Model.Physics.Parts.Count > 1 )
		{
			var modelPhysics = Components.GetOrCreate<ModelPhysics>();
			modelPhysics.Model = ModelRenderer.Model;
			modelPhysics.Renderer = ModelRenderer;
		}
		else
		{
			var modelCollider = Components.GetOrCreate<ModelCollider>();
			modelCollider.Model = ModelRenderer.Model;
			Rigidbody = Components.GetOrCreate<Rigidbody>();
		}
	}
}
