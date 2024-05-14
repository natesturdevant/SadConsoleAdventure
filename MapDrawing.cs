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
        
       
        public int mapIndex = 0;
        public void drawMaps(Map map)
        {
            //int mapIndex = 0;
            /*
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    int mapIndex = map.WorldPosition.Y * 5 + map.WorldPosition.X; // Assuming 5x5 map grid
                    
                    var stream = new FileStream($"C:/Adventure Games/REXPaint-v1.70/REXPaint-v1.70/images/Map{mapIndex}.xp", FileMode.Open);
                    //var stream = new FileStream($"C:/Adventure Games/REXPaint-v1.70/REXPaint-v1.70/images/Map0.xp", FileMode.Open);
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
            */


            /*
                int mapIndex = map.WorldPosition.Y * 5 + map.WorldPosition.X; // Assuming logic to calculate valid map index
                var stream = new FileStream($"C:/Adventure Games/REXPaint-v1.70/REXPaint-v1.70/images/Map{mapIndex}.xp", FileMode.Open);
                REXPaintImage rexPaintImage = REXPaintImage.Load(stream);
                var cellSurface = rexPaintImage.ToCellSurface()[0];
                map.SurfaceObject.Surface = cellSurface;
            */


            int mapIndex = map.WorldPosition.Y * 5 + map.WorldPosition.X;
            string filePath = $"C:/Adventure Games/REXPaint-v1.70/REXPaint-v1.70/images/Map{mapIndex}.xp";

            // Check if the calculated file exists
            if (File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    REXPaintImage rexPaintImage = REXPaintImage.Load(stream);
                    var cellSurface = rexPaintImage.ToCellSurface()[0];
                    map.SurfaceObject.Surface = cellSurface;
                }
            }
            else
            {
                // Use default map (Map12.xp)
                filePath = "C:/Adventure Games/REXPaint-v1.70/REXPaint-v1.70/images/Map12.xp";
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    REXPaintImage rexPaintImage = REXPaintImage.Load(stream);
                    var cellSurface = rexPaintImage.ToCellSurface()[0];
                    map.SurfaceObject.Surface = cellSurface;
                }
            }

        }
    }
}
