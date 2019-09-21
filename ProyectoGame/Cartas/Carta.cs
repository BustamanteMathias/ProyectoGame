using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGame
{
    public class Carta
    {
        #region ATRIBUTOS
        private EClase claseCarta;
        private EElemento elementoCarta;
        private EGrado gradoCarta;
        private int idCarta;
        private int nivelCarta;
        private string nombreCarta;
        private string descripCarta;

        private float ataqueFisico;
        private float ataqueMagico;
        private float defensaFisica;
        private float defensaMagica;
        
        #endregion

        #region PROPIEDADES
        public EClase Clase
        {
            get { return this.claseCarta; }
            set { this.claseCarta = value; }
        }
        public EElemento Elemento
        {
            get { return this.elementoCarta; }
            set { this.elementoCarta = value; }
        }
        public EGrado Grado
        {
            get { return this.gradoCarta; }
            set { this.gradoCarta = value; }
        }
        public int ID
        {
            get { return this.idCarta; }
            set { this.idCarta = value; }

        }
        public int Nivel
        {
            get { return this.nivelCarta; }
            set { this.nivelCarta = value; }
        }
        public string Nombre
        {
            get { return this.nombreCarta; }
            set { this.nombreCarta = value; }
        }
        public string Descripcion
        {
            get { return this.descripCarta; }
            set { this.descripCarta = value; }
        }
        public float AtaqueFisico
        {
            get { return this.ataqueFisico; }
            set { this.ataqueFisico = value; }
        }
        public float AtaqueMagico
        {
            get { return this.ataqueMagico; }
            set { this.ataqueMagico = value; }
        }
        public float DefensaFisica
        {
            get { return this.defensaFisica; }
            set { this.defensaFisica = value; }
        }
        public float DefensaMagica
        {
            get { return this.defensaMagica; }
            set { this.defensaMagica = value; }
        }
        
        #endregion

        #region CONSTRUCTORES
        public Carta()
        {
            this.claseCarta = 0;
            this.elementoCarta = 0;
            this.gradoCarta = 0;
            this.idCarta = 0;
            this.nivelCarta = 0;
            this.nombreCarta = "Default";
            this.descripCarta = "AnyDescription";

            this.ataqueFisico = 1;
            this.ataqueMagico = 1;
            this.defensaFisica = 1;
            this.defensaMagica = 1;
        }

        public Carta(int id, int nivel, string nombre, string descripcion, EClase clase, EGrado grado, EElemento elemento, float aFisico, float aMagico, float dFisica, float dMagica) : this()
        {
            this.Clase = clase;
            this.Elemento = elemento;
            this.Grado = grado;
            this.ID = id;
            this.Nivel = nivel;
            this.Nombre = nombre;
            this.Descripcion = descripcion;

            this.AtaqueFisico = aFisico;
            this.AtaqueMagico = aMagico;
            this.DefensaFisica = dFisica;
            this.DefensaMagica = dMagica;
        }
        #endregion

        #region METODOS
        public string Mostrar()
        {
            return string.Format("" +
                "ID: {0}\t\t|Nivel: {1}|\tGrado: {10}\n\n" +
                "-Nombre: {2}\t -Descripcion: {3}\n" +
                "-Tipo: {4}\t\t -Elemento: {5}\n\n" +
                "\tAtaque Fisico:\t {6}\n" +
                "\tAtaque Magico:\t {7}\n" +
                "\tDefensa Fisica:\t {8}\n" +
                "\tDefensa magica:\t {9}\n--------------------------------------------------------------\n",
                this.ID.ToString(), this.Nivel.ToString(), this.Nombre, this.Descripcion, this.Clase.ToString(), this.Elemento.ToString(),
                this.AtaqueFisico.ToString(), this.AtaqueMagico.ToString(), this.DefensaFisica.ToString(), this.DefensaMagica.ToString(), this.Grado.ToString());
        }
        public static implicit operator string(Carta c)
        {
            return c.Mostrar();
        } 
        #endregion
    }
}
