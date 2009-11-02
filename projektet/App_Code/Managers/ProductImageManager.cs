using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>
/// Summary description for ProductImageManager
/// </summary>
public class ProductImageManager
{
    //***Refaktoreringsmetoder***//
    //Refaktoreringskod för att se om någon rad har påverkats av kommandot, om så inte är fallet returners inget
    public static bool IsChangedRowFromExecutionSuccessful(DbCommand comm)
    {
        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception)
        {

        }
        return (result != -1);
    }

    public ProductImageManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public struct IncludeToFill
    {
        public bool Id;
        public bool ImageUrl;
    }

    public static ProductImageItem FillOne(DataRow r, IncludeToFill inc)
    {
        ProductImageItem p = new ProductImageItem();
        if (inc.Id) p.Id = (long)r["Id"];
        if (inc.ImageUrl) p.ImageURL = (string)r["ImageURL"];
        return p;
    }

    public static List<ProductImageItem> FillAll(DataTable table, IncludeToFill inc)
    {
        List<ProductImageItem> list = new List<ProductImageItem>();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            list.Add(FillOne(table.Rows[i], inc));
        }

        return list;
    }

    public static List<ProductImageItem> GetImagesForProduct(long productId)
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandType = CommandType.Text;

        comm.CommandText = "SELECT * FROM ProductImage WHERE ProductId = @ProductId";

        comm.CreateAndAddParameter("@ProductId", productId, DbType.Int32);

        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        //List<ProductImageItem> list = new List<ProductImageItem>();
        //ProductImageItem p;
        //for (int i = 0; i < table.Rows.Count; i++)
        //{
        //    p = new ProductImageItem();

        //    p.Id = (int)table.Rows[i]["Id"];
        //    p.ImageURL = (string)table.Rows[i]["ImageURL"];
        //    list.Add(p);

        //}

        IncludeToFill inc;
        inc.Id = true;
        inc.ImageUrl = true;

        return FillAll(table, inc);
    }

    public static long InsertProductImage(long productId, string imageUrl)
    {
        DbCommand comm = DataAccess.CreateCommand("InsertProductImage");
        comm.CommandType = CommandType.StoredProcedure;
        comm.CreateAndAddParameter("@productId", productId, DbType.Int32);
        comm.CreateAndAddParameter("@imageUrl", imageUrl, DbType.String);
        return long.Parse(DataAccess.ExecuteScalar(comm));

    }

    public static bool DeleteProductImage(long productId, long imageId)
    {
        DbCommand comm = DataAccess.CreateCommand("DeleteProductImage");
        comm.CommandType = CommandType.StoredProcedure;
        comm.CreateAndAddParameter("@productId", productId, DbType.Int32);
        comm.CreateAndAddParameter("@imageId", imageId, DbType.Int32);
        return IsChangedRowFromExecutionSuccessful(comm);
    }

    public static System.Drawing.Image FixedSizeThumb(System.Drawing.Image imgPhoto)
    {
        //ändra önskad width och height här
        int Width = 140;
        int Height = 140;
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = System.Convert.ToInt16((Width -
                          (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = System.Convert.ToInt16((Height -
                          (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height,
                          PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.Black);
        grPhoto.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }
    public static System.Drawing.Image FixedSizeImage(System.Drawing.Image imgPhoto)
    {
        //ändra önskad width och height här
        int Width = 500;
        int Height = 500;
        if (imgPhoto.Width < 500 && imgPhoto.Height < 500)
        {
            return imgPhoto;
            
        }
        else
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
       
    }
}
