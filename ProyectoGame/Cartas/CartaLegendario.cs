using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGame
{
    public class CartaLegendario : Carta
    {
        private ESkillsLegendario SKILL_LEGENDARIO;
        private ESkillsRaro SKILL_RARO;

        public ESkillsLegendario Skill_Legendario
        {
            get { return this.SKILL_LEGENDARIO; }
            set { this.SKILL_LEGENDARIO = value; }
        }
        public ESkillsRaro Skill_Raro
        {
            get { return this.SKILL_RARO; }
            set { this.SKILL_RARO = value; }
        }

        public CartaLegendario(int id, int nivel, string nombre, string descripcion, EClase clase, EElemento elemento, float aFisico, float aMagico, float dFisica, float dMagica, ESkillsRaro sRaro, ESkillsLegendario sLegendario) : base(id, nivel, nombre, descripcion, clase, EGrado.Legendario, elemento, aFisico, aMagico, dFisica, dMagica)
        {
            this.Skill_Legendario = sLegendario;
            this.Skill_Raro = sRaro;
        }
    }
}
