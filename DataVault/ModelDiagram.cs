using System.Data.Entity.Infrastructure;
using System.Text;
using System.Xml;
using DataVault.DataModels;

namespace DataVault
{
    public class ModelDiagram
    {
        public static void Generate(string path)
        {
            using (var ctx = new RenderFarm())
            {
                using (var writer = new XmlTextWriter(path, Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }
        }
    }
}