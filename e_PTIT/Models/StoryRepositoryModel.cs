using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace e_PTIT.Models
{
    public class StoryRepositoryModel
    {
        private EPtitDataClassesDataContext db = new EPtitDataClassesDataContext();
        public Models.Story StoryObject { get; set; } 
        

        public StoryRepositoryModel()
        {
            StoryObject = new Models.Story();
        } 

        public StoryRepositoryModel(int pkStoryId)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Story>(c => c.StoryContents);
            dlo.LoadWith<Story>(c => c.MagazineEdition);
            dlo.LoadWith<Story>(c => c.ContentTemplate);
            db.LoadOptions = dlo;
            StoryObject = db.Stories.Where(mag => mag.pkStoryId == pkStoryId).FirstOrDefault();
        }

    }
}