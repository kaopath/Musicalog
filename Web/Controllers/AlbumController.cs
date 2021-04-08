using Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AlbumController : Controller
    {
        public ActionResult Album()
        {
            var albums = new AlbumService().GetAlbums(1);
            return View(albums);
        }

        public ActionResult AlbumDetail(int? id)
        {
            if (id > 0)
            {
                var album = new AlbumService().GetAlbum(id);
                return View(album);
            }

            return View(new Entity.Album());
        }

        [HttpPost]
        public ActionResult AlbumDetail(Album album)
        {
            new AlbumService().SaveAlbum(album);

            return RedirectToAction("Album");
        }

        [HttpPost]
        public ActionResult UpdateAlbum(Album album)
        {
            new AlbumService().SaveAlbum(album);
     
            return RedirectToAction("Album");
        }

        [HttpPost]
        public ActionResult DeleteAlbum(int id)
        {
            new AlbumService().DeleteAlbum(id);

            return RedirectToAction("Album");
        }

    }
}