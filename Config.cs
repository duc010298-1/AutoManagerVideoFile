using System;
using System.Runtime.Serialization;

namespace AutoManagerVideoFile
{
    [Serializable]
    class Config
    {
        public string InputDirectory;
        public string OutDirectory;
    }
}
