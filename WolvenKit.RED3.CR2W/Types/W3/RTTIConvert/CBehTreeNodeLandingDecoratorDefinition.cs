using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehTreeNodeLandingDecoratorDefinition : IBehTreeNodeFlightDecoratorDefinition
	{
		[Ordinal(1)] [RED("landingMaxHeight")] 		public CBehTreeValFloat LandingMaxHeight { get; set;}

		[Ordinal(2)] [RED("landingForwardOffset")] 		public CBehTreeValFloat LandingForwardOffset { get; set;}

		[Ordinal(3)] [RED("tolerationDistance")] 		public CBehTreeValFloat TolerationDistance { get; set;}

		public CBehTreeNodeLandingDecoratorDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehTreeNodeLandingDecoratorDefinition(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}