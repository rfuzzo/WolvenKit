using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SQuestThreadSuspensionData : CVariable
	{
		[Ordinal(1)] [RED("scopeBlockGUID")] 		public CGUID ScopeBlockGUID { get; set;}

		[Ordinal(2)] [RED("scopeData", 154,0)] 		public CByteArray ScopeData { get; set;}

		public SQuestThreadSuspensionData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SQuestThreadSuspensionData(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}