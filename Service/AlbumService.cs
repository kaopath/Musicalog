using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class AlbumService : IAlbumService
    {
        public int SaveAlbum(Album album)
        {
            using (var db = new MusicDbContext())
            {
                if (album.Id > 0)
                {
                    db.Albums.Attach(album);
                    db.Entry(album).State = EntityState.Modified;
                }
                else
                {
                    db.Albums.Add(album);
                }
              
                db.SaveChanges();

                return album.Id;
            }
        }

        public bool DeleteAlbum(int id)
        {
            using (var db = new MusicDbContext())
            {
                var album = db.Albums.Find(id);
                if (album == null)
                {
                    return false;
                }

                db.Albums.Remove(album);

                return db.SaveChanges() > 0;
            }
        }
        public Album GetAlbum(int? id)
        {
            using (var db = new MusicDbContext())
            {
                return db.Albums.Find(id);
            }
        }

        public IList<Album> GetAlbums(int pageIndex)
        {
            int pageSize = 10;//in a real life we will read from app config
            using (var db = new MusicDbContext())
            {
                return db.Albums.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
