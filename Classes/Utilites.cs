using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
   public class Utilites
    {
        public static byte[] imagetobytearray(System.Drawing.Image imagein)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    imagein.Save(ms, imagein.RawFormat);return ms.ToArray();
                }
                catch { return null; }
                
            }
            
        }
        public static Image ByteArrayToImage (byte[] bytearrayin)
        {
            MemoryStream ms = new MemoryStream(bytearrayin);
            Image returnimage = Image.FromStream(ms);
            return returnimage;
        }
      static CPrinting.PrintedDocument PD;
        public static void Print(string reportTitle, DataTable dt)
        {
            CPrinting.CPrinting Drawer = new CPrinting.CPrinting();
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            PD = new CPrinting.PrintedDocument();
            CPrinting.PrintPreview PP = new CPrinting.PrintPreview(PD);
            Drawer = new CPrinting.CPrinting();
            Drawer.printedDataTable.Add(dt);
            Drawer.header.Add(reportTitle);

            Drawer.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(40, 40, 100, 100);
            Drawer.PrintDocument.DefaultPageSettings.Landscape = true;
            Drawer.fonts[CPrinting.CPrinting.FontElement.ColumnHeader] = new System.Drawing.Font("Cambria", 10);
            Drawer.fonts[CPrinting.CPrinting.FontElement.Cell] = new System.Drawing.Font("tahoma", 8);
            Drawer.columnsFonts.Add("Name", new System.Drawing.Font("Cambria", 10));

            //Drawer.leftLogoSize = Drawer.rightLogoSize = img.Size;
            //Drawer.leftLogo = img;

            Drawer.columnsDirection.Add("Name", sf);
            Drawer.footer = "";
            Drawer.print();
        }
    }
}
