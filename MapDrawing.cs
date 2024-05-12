using SadConsole.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Read or process the stream here



namespace SadConsoleGame
{
   

    internal class MapDrawing
    {
        


        public void drawMaps(Map map)
        {


            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    //int mapIndex = y * 5 + x; // Assuming 5x5 map grid
                    //string filePath = String.Format("C:/Adventure Games/REXPaint-v1.70/REXPaint-v1.70/images/Map{7}.xp", mapIndex);
                    var stream = new FileStream("C:/Adventure Games/REXPaint-v1.70/REXPaint-v1.70/images/Lab.xp", FileMode.Open);
                    // var stream = new FileStream("C:/myFilePath/00.xp", FileMode.Open);
                    //REXPaintImage rexPaintImage;
                    //rexPaintImage = REXPaintImage.Load(stream);
                    //var cellSurface = rexPaintImage.ToCellSurface()[0];
                    //map.SurfaceObject.Surface = cellSurface;


                    //var stream = new FileStream(filePath, FileMode.Open);
                    REXPaintImage rexPaintImage = REXPaintImage.Load(stream);
                    var cellSurface = rexPaintImage.ToCellSurface()[0];
                    map.SurfaceObject.Surface = cellSurface;



                }
            }
        }
    }
}
