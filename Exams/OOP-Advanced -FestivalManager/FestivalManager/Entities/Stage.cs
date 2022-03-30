namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private List<ISet> sets;
        private List<ISong> songs;
        private List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }
        protected string Name { get; }
        public IReadOnlyCollection<ISet> Sets => (IReadOnlyCollection<ISet>)this.sets;
        public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>)this.songs;
        public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>)this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            var performer = this.performers.FirstOrDefault(p => p.Name == name);

            return performer;

        }

        public ISet GetSet(string name)
        {
            var set = this.sets.FirstOrDefault(p => p.Name == name);

            return set;

        }

        public ISong GetSong(string name)
        {
            var song = this.songs.FirstOrDefault(p => p.Name == name);

            return song;
        }

        public bool HasPerformer(string name)
        {
            if (this.performers.Any(p => p.Name == name))
            {
                return true;
            }
            return false;
        }

        public bool HasSet(string name)
        {
            if (this.sets.Any(p => p.Name == name))
            {
                return true;
            }
            return false;
        }

        public bool HasSong(string name)
        {
            if (this.songs.Any(p => p.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}
