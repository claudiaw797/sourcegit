﻿using System.Threading.Tasks;

namespace SourceGit.ViewModels
{
    public class DeleteSubmodule : Popup
    {
        public string Submodule
        {
            get;
            private set;
        }

        public DeleteSubmodule(Repository repo, string submodule)
        {
            _repo = repo;
            Submodule = submodule;
        }

        public override async Task<bool> Sure()
        {
            _repo.SetWatcherEnabled(false);
            ProgressDescription = "Deleting submodule ...";

            var log = _repo.CreateLog("Delete Submodule");
            Use(log);

            var succ = await new Commands.Submodule(_repo.FullPath)
                .Use(log)
                .DeleteAsync(Submodule);

            log.Complete();
            _repo.SetWatcherEnabled(true);
            return succ;
        }

        private readonly Repository _repo = null;
    }
}
