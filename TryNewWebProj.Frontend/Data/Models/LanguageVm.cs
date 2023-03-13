using System.ComponentModel.DataAnnotations;

namespace TryNewWebProj.Frontend.Data.Models
{
    public class LanguageListVm
    {
        public IList<LanguageVm> Languages { get; set; }
    }
    public class LanguageVm
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
    }
}