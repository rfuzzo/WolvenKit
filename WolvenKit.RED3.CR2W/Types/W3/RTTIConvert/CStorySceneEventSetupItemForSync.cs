using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneEventSetupItemForSync : CStorySceneEvent
	{
		[Ordinal(1)] [RED("itemName")] 		public CName ItemName { get; set;}

		[Ordinal(2)] [RED("activate")] 		public CBool Activate { get; set;}

		[Ordinal(3)] [RED("actorToSyncTo")] 		public CName ActorToSyncTo { get; set;}

		public CStorySceneEventSetupItemForSync(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneEventSetupItemForSync(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}