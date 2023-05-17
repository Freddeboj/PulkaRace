// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Coherence.Toolkit;
	using Coherence.Toolkit.Bindings;
	using Coherence.Entity;
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Toolkit.Bindings.ValueBindings;
	using Coherence.Toolkit.Bindings.TransformBindings;
	using Coherence.Connection;
	using Coherence.Log;
	using Logger = Coherence.Log.Logger;
	using UnityEngine.Scripting;

	public class Binding_7f974e5226933614abe6e75b3eb39f5a_3200ae35_f992_46dd_bea0_a8455c5761af : PositionBinding
	{
		public override string CoherenceComponentName => "WorldPosition";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector3 Value
		{
			get => (Vector3)(UnityEngine.Vector3)(coherenceSync.coherencePosition);
			set => coherenceSync.coherencePosition = (UnityEngine.Vector3)(value);
		}

		protected override Vector3 ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((WorldPosition)coherenceComponent).value;
			if (!coherenceSync.HasParentWithCoherenceSync)
            {
                value += floatingOriginDelta;
            }
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (WorldPosition)coherenceComponent;
			update.value = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new WorldPosition();
		}
	}

	public class Binding_7f974e5226933614abe6e75b3eb39f5a_f2afe13a_8e77_4eba_b803_8b269d7f4514 : RotationBinding
	{
		public override string CoherenceComponentName => "WorldOrientation";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Quaternion Value
		{
			get => (Quaternion)(UnityEngine.Quaternion)(coherenceSync.coherenceRotation);
			set => coherenceSync.coherenceRotation = (UnityEngine.Quaternion)(value);
		}

		protected override Quaternion ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((WorldOrientation)coherenceComponent).value;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (WorldOrientation)coherenceComponent;
			update.value = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new WorldOrientation();
		}
	}


	[Preserve]
	[AddComponentMenu("coherence/Baked/Baked '[Player]' (auto assigned)")]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceSync__char_91_Player__char_93_ : CoherenceSyncBaked
	{
		private CoherenceSync coherenceSync;
		private Logger logger;

		// Cached targets for commands

		private IClient client;
		private CoherenceMonoBridge monoBridge => coherenceSync.MonoBridge;

		protected void Awake()
		{
			coherenceSync = GetComponent<CoherenceSync>();
			coherenceSync.usingReflection = false;

			logger = coherenceSync.logger.With<CoherenceSync__char_91_Player__char_93_>();
			if (coherenceSync.TryGetBindingByGuid("3200ae35-f992-46dd-bea0-a8455c5761af", "position", out Binding InternalWorldPosition_Translation_value))
			{
				var clone = new Binding_7f974e5226933614abe6e75b3eb39f5a_3200ae35_f992_46dd_bea0_a8455c5761af();
				InternalWorldPosition_Translation_value.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalWorldPosition_Translation_value)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).position");
			}
			if (coherenceSync.TryGetBindingByGuid("f2afe13a-8e77-4eba-b803-8b269d7f4514", "rotation", out Binding InternalWorldOrientation_Rotation_value))
			{
				var clone = new Binding_7f974e5226933614abe6e75b3eb39f5a_f2afe13a_8e77_4eba_b803_8b269d7f4514();
				InternalWorldOrientation_Rotation_value.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalWorldOrientation_Rotation_value)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).rotation");
			}
		}

		public override List<ICoherenceComponentData> CreateEntity()
		{
			if (coherenceSync.UsesLODsAtRuntime && (Archetypes.IndexForName.TryGetValue(coherenceSync.Archetype.ArchetypeName, out int archetypeIndex)))
			{
				var components = new List<ICoherenceComponentData>()
				{
					new ArchetypeComponent
					{
						index = archetypeIndex
					}
				};

				return components;
			}
			else
			{
				logger.Warning($"Unable to find archetype {coherenceSync.Archetype.ArchetypeName} in dictionary. Please, bake manually (coherence > Bake)");
			}

			return null;
		}

		public override void Initialize(CoherenceSync sync, IClient client)
		{
			if (coherenceSync == null)
			{
				coherenceSync = sync;
			}
			this.client = client;
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				default:
					logger.Warning($"[CoherenceSync__char_91_Player__char_93_] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}
