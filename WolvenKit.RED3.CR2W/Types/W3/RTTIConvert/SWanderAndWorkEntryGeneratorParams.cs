using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SWanderAndWorkEntryGeneratorParams : CVariable
	{
		[Ordinal(1)] [RED("creatureEntry")] 		public SCreatureEntryEntryGeneratorNodeParam CreatureEntry { get; set;}

		[Ordinal(2)] [RED("wander")] 		public SWanderHistoryEntryGeneratorParams Wander { get; set;}

		[Ordinal(3)] [RED("work")] 		public SWorkWanderSmartAIEntryGeneratorParam Work { get; set;}

		public SWanderAndWorkEntryGeneratorParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SWanderAndWorkEntryGeneratorParams(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}