using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IAboutusEditorRepository
    {
        List<Aboutuseditor> GETAABOUTUSEDITOR();

        bool CREATEABOUTUSEDITOR(Aboutuseditor aboutuseditor);

        bool UPDATEABOUTUSEDITOR(Aboutuseditor aboutuseditor);

        string DELETEABOUTUSEDITOR(int id);
    }
}
