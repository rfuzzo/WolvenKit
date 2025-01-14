using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3PointOfInterestEntity : CGameplayEntity
	{
		[Ordinal(1)] [RED("toDestroy")] 		public CBool ToDestroy { get; set;}

		[Ordinal(2)] [RED("assignedDispenser")] 		public CHandle<W3POIDispenser> AssignedDispenser { get; set;}

		public W3PointOfInterestEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3PointOfInterestEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}