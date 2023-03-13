using System.ComponentModel.DataAnnotations;

namespace TryNewWebProj.Frontend.Data.Models
{
    public class WordListVm
    {
        public IList<WordVm> Words { get; set; }
    }

    public class WordVm
    {
        public Guid? LanguageId { get; set; }
        public Guid? Id { get; set; }
        public string WordValue { get; set; }
        public string Translate { get; set; }
    }

    public class SettingsWordVm
    {
        public Guid WordId { set; get; }
        public Guid Id { get; set; }
        public int? ProcentLearning { get; set; }

        public int? Stage { get; set; }
        //0-6 point   - 1 Stage
        //6-12 point  - 2 Stage
        //12-18 point - 3 Stage
        //18-24 point - 4 Stage
        public int? StagePoint { get; set; }
        public int? StagePointBall { get; set; }
        public DateTime? LastTreaning { get; set; }
        public DateTime CreationDate { get; set; }
        public int Difficult { get; set; }
    }

    public class Sett
    {
        public Guid WordId { get; set; }
        public bool Learn { get; set; }
    }
}