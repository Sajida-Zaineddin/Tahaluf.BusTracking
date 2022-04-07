using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class AboutusEditorService : IAboutusEditorService
    {
        private readonly IAboutusEditorRepository aboutusEditorRepository;
        public AboutusEditorService(IAboutusEditorRepository _aboutusEditorRepository)
        {
            aboutusEditorRepository = _aboutusEditorRepository;
        }
        public bool CREATEABOUTUSEDITOR(Aboutuseditor aboutuseditor)
        {
            return aboutusEditorRepository.CREATEABOUTUSEDITOR(aboutuseditor);
        }
        public string DELETEABOUTUSEDITOR(int id)
        {
            return aboutusEditorRepository.DELETEABOUTUSEDITOR(id);
        }
        public List<Aboutuseditor> GETAABOUTUSEDITOR()
        {
            return aboutusEditorRepository.GETAABOUTUSEDITOR();
        }
        public bool UPDATEABOUTUSEDITOR(Aboutuseditor aboutuseditor)
        {
            return aboutusEditorRepository.UPDATEABOUTUSEDITOR(aboutuseditor);
        }
    }
}
