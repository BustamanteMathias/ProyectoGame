using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGame
{
    public class CartaRaro : Carta
    {
        private ESkillsRaro SKILL_RARO;

        public ESkillsRaro Skill_Raro
        {
            get { return this.SKILL_RARO; }
            set { this.SKILL_RARO = value; }
        }
        public CartaRaro(int id, int nivel, string nombre, string descripcion, EClase clase, EElemento elemento, float aFisico, float aMagico, float dFisica, float dMagica, ESkillsRaro sRaro) : base(id, nivel, nombre, descripcion, clase, EGrado.Raro, elemento, aFisico, aMagico, dFisica, dMagica)
        {
            this.Skill_Raro = sRaro;
        }

        //AGREGAR SLOT DE SKILLS
    }
}
