using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EntidadesCartuchera
{
    public class ActualizarData
    {
        public static async Task<List<Cartuchera<Utiles>>> TraerRegristros() 
        {
            List<Cartuchera<Utiles>> listadoCartucheras = new List<Cartuchera<Utiles>>();
            listadoCartucheras = await Task.Run(() => 
            {
                Thread.Sleep(3000);
                return SQLClass.LeerCartucheras();

            });
            return listadoCartucheras;
        }
    }
}
