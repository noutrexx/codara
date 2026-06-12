using System.Collections.Generic;
using Codara.Domain;

namespace Codara.Application
{
    public interface IMistakeRepository
    {
        IReadOnlyList<MistakeRecord> Load();
        void Save(IReadOnlyList<MistakeRecord> mistakes);
    }
}
