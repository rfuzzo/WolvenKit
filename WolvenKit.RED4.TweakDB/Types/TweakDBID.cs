namespace WolvenKit.RED4.TweakDB.Types
{
    public partial class TweakDBID
    {
        private TweakDBFile _tweakDbFile;

        public string Name
        {
            get
            {
                if (_tweakDbFile != null && _tweakDbFile.StringFile != null)
                {
                    return _tweakDbFile.StringFile.GetName(this);
                }

                return $"<Hash: {Hash:X}, Length: {Length}>";
            }
        }

        public gamedataTweakDBRecord RefValue
        {
            get
            {
                if (_tweakDbFile != null && _tweakDbFile.RecordDict.ContainsKey(this))
                {
                    return _tweakDbFile.RecordDict[this];
                }

                return null;
            }
        }

        public void SetTweakDBFile(TweakDBFile tweakDbFile) => _tweakDbFile = tweakDbFile;

        public override string ToString() => Name;
    }
}
