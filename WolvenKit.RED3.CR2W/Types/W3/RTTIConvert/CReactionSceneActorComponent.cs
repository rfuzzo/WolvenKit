using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CReactionSceneActorComponent : CComponent
	{
		[Ordinal(1)] [RED("cooldownInterval")] 		public CFloat CooldownInterval { get; set;}

		[Ordinal(2)] [RED("sceneStartedSuccesfully")] 		public CBool SceneStartedSuccesfully { get; set;}

		public CReactionSceneActorComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CReactionSceneActorComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}