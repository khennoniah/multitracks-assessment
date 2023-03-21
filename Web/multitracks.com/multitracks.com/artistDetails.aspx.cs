using DataAccess;
using System;
using System.Data;

public partial class artistDetails : ArtistDetailsPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        if (Request["artistID"] != null)
        {
            try
            {
                sql.Parameters.Add("@artistID", Request["artistID"]);
                var data = sql.ExecuteStoredProcedureDS("GetArtistDetails");

                // TODO: probably should do this more dynamically
                // in case the order of the SP changes
                ExtractArtistData(data.Tables[0]);
                ExtractAlbumData(data.Tables[1]);
                ExtractSongData(data.Tables[2]);


            }
            catch
            {
                // TODO: error
            }
        }
        else { 
            // TODO:
        }

    }

    protected void ExtractAlbumData(DataTable albumDT) {
        albums.DataSource = albumDT;
        albums.DataBind();
    }

    protected void ExtractArtistData(DataTable artistDT)
    {
        hero.ImageUrl = Convert.ToString(artistDT.Rows[0]["heroURL"]);
        hero.AlternateText = Convert.ToString(artistDT.Rows[0]["title"]);
        hero.DataBind();

        info_box.ImageUrl = Convert.ToString(artistDT.Rows[0]["imageURL"]);
        info_box.DataBind();

        name_link.Text = Convert.ToString(artistDT.Rows[0]["title"]);
        name_link.DataBind();

        bio.Text = Convert.ToString(artistDT.Rows[0]["biography"]);
        bio.DataBind();
    }

    protected void ExtractSongData(DataTable songDT)
    {
        // TODO: how do I determine "top" songs?
        topSongs.DataSource = songDT;
        topSongs.DataBind();

    }
}