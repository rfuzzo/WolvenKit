using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CSSceneTimetableEntry : CVariable
	{
		[Ordinal(1)] [RED("time")] 		public GameTimeInterval Time { get; set;}

		[Ordinal(2)] [RED("scenes", 2,0)] 		public CArray<CSSceneTimetableScenesEntry> Scenes { get; set;}

		public CSSceneTimetableEntry(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CSSceneTimetableEntry(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}