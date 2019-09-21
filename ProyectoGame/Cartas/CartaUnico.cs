using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGame
{
    public class CartaUnico : Carta
    {
        private ESkillsLegendario SKILL_LEGENDARIO;
        private ESkillsRaro SKILL_RARO;
        private ESkillsMitico SKILL_MITICO;
        private ESkillsUnico SKILL_UNICO;

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
        public ESkillsMitico Skill_Mitico
        {
            get { return this.SKILL_MITICO; }
            set { this.SKILL_MITICO = value; }
        }
        public ESkillsUnico Skill_Unico
        {
            get { return this.SKILL_UNICO; }
            set { this.SKILL_UNICO = value; }
        }

        public CartaUnico(int id, int nivel, string nombre, string descripcion, EClase clase, EElemento elemento, float aFisico, float aMagico, float dFisica, float dMagica, ESkillsRaro sRaro, ESkillsLegendario sLegendario, ESkillsMitico sMitico, ESkillsUnico sUnico) : base(id, nivel, nombre, descripcion, clase, EGrado.Unico, elemento, aFisico, aMagico, dFisica, dMagica)
        {
            this.Skill_Legendario = sLegendario;
            this.Skill_Raro = sRaro;
            this.Skill_Mitico = sMitico;
            this.Skill_Unico = sUnico;
        }
    }
}
