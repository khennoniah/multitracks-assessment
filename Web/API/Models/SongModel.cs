using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class SongModel
    {
        public class RequestParams
        {
            // max number of items per page
            const int maxPageSize = 10;
            // default number of items per page
            private int _pageSize = 5;

            // page to start at
            public int PageNumber { get; set; } = 1;

            // number of items per page
            public int PageSize
            {
                get { return _pageSize; }
                set { _pageSize = (value > maxPageSize ? _pageSize : value); }
            }
        }
        public class Song {
            public int SongId { get; set; }
            public DateTime DateCreation { get; set; }
            public int AlbumID { get; set; }
            public int ArtistID { get; set; }
            public string Title { get; set; }
            public decimal Bpm { get; set; }
            public string TimeSignature { get; set; }
            public bool MultiTracks { get; set; }
            public bool CustomMix { get; set; }
            public bool Chart { get; set; }
            public bool RehearsalMix { get; set; }
            public bool Patches { get; set; }
            public bool SongSPecificPatches { get; set; }
            public bool ProPresenter { get; set; }

            public Song(DataRow data) {
                SongId = (int)data["songID"];
                DateCreation = (DateTime)data["dateCreation"];
                AlbumID = (int)data["albumID"];
                ArtistID = (int)data["artistID"];
                Title = (string)data["title"];
                Bpm = (decimal)data["bpm"];
                TimeSignature = (string)data["timeSignature"];
                MultiTracks = (bool)data["multitracks"];
                CustomMix = (bool)data["customMix"];
                Chart = (bool)data["chart"];
                RehearsalMix = (bool)data["rehearsalMix"];
                Patches = (bool)data["patches"];
                SongSPecificPatches = (bool)data["songSPecificPatches"];
                ProPresenter = (bool)data["proPresenter"];
            }

        }

    }
}
