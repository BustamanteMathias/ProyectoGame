using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace ProyectoGame
{
    public class NPC
    {
        private int     id;
        private string  nombre;
        private string  descripcion;

        private float   vida;
        private int     nivel;
        private double  experiencia;

        private float ataqueFisico;
        private float ataqueMagico;
        private float defensaFisica;
        private float defensaMagica;

        #region CONSTRUCTOR
        public NPC(int id, string nombre, string descripcion, float vida, int nivel, double experiencia, float aFisico, float aMagico, float dFisica, float dMagica)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.vida = vida;
            this.nivel = nivel;
            this.experiencia = experiencia;
            this.ataqueFisico = aFisico;
            this.ataqueMagico = aMagico;
            this.defensaFisica = dFisica;
            this.defensaMagica = dMagica;
        }
        #endregion

        #region PROPIEDADES DE LECTURA Y ESCRITURA
        public int ID { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public float Vida { get { return this.vida; } set { this.vida = value; } }
        public int Nivel { get { return this.nivel; } set { this.nivel = value; } }
        public double Experiencia { get { return this.experiencia; } set { this.experiencia = value; } }
        public float AtaqueFisico { get { return this.ataqueFisico; } set { this.ataqueFisico = value; } }
        public float AtaqueMagico { get { return this.ataqueMagico; } set { this.ataqueMagico = value; } }
        public float DefensaFisica { get { return this.defensaFisica; } set { this.defensaFisica = value; } }
        public float DefensaMagica { get { return this.defensaMagica; } set { this.defensaMagica = value; } } 
        #endregion

        public string MostrarInfoNPC ()
        {
            return string.Format("ID: {0}\nNombre: {1}\nDescripcion: {2}\n\nVida: {3}\nNivel: {4}\nExperiencia: {5}\n\nAtaque Fisico: {6}\nAtaque Magico: {7}\nDefensa Fisica: {8}\nDefensa Magica: {9}\n\n----------------------------------------------------------\n\n",
                this.id, this.nombre, this.descripcion, this.vida, this.nivel, this.experiencia, this.ataqueFisico, this.ataqueMagico, this.defensaFisica, this.defensaMagica);
        }

        public static implicit operator string(NPC c)
        {
            return c.MostrarInfoNPC();
        }
    }
}
