using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class grsGatherAreaReplicatedInfo : CVariable
	{
		[Ordinal(0)] [RED("enteredPlayerIDs", 7)] public CStatic<netPeerID> EnteredPlayerIDs { get; set; }
		[Ordinal(1)] [RED("hasActiveQuestListener")] public CBool HasActiveQuestListener { get; set; }
		[Ordinal(2)] [RED("enabled")] public CBool Enabled { get; set; }

		public grsGatherAreaReplicatedInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}