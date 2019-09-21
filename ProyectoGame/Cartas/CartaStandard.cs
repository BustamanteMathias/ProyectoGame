using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGame
{
    public class CartaStandard : Carta
    {
        public CartaStandard(int id, int nivel, string nombre, string descripcion, EClase clase, EElemento elemento, float aFisico, float aMagico, float dFisica, float dMagica) : base (id, nivel, nombre, descripcion, clase, EGrado.Standar, elemento, aFisico, aMagico, dFisica, dMagica)
        {

        }
    }
}
