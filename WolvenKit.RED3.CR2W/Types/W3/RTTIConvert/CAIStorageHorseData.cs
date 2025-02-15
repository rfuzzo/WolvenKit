using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAIStorageHorseData : IScriptable
	{
		[Ordinal(1)] [RED("horseEntity")] 		public CHandle<CActor> HorseEntity { get; set;}

		[Ordinal(2)] [RED("horseComponent")] 		public CHandle<W3HorseComponent> HorseComponent { get; set;}

		public CAIStorageHorseData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAIStorageHorseData(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}