namespace Drill05.Entities
{
    public class Instructor
    {
        public int Id {get;set;}
        public string FullName {get;set;} = default ! ;
        public string Email {get;set;} = default ! ;
        public DateTime CreatedAt {get;set;}

        public ICollection<TrainingTrack> TrainingTracks {get;set;} = new List<TrainingTrack>(); 

    }
}